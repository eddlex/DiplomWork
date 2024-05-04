import json
import numpy as np
from scipy.optimize import minimize
from sqlalchemy import create_engine
import pandas as pd
import sys
import platform
import pyodbc

db_config_path = __file__.replace('schedule.py', 'DBconn.json') 

try:
    with open(db_config_path, 'r') as config_file:
        db_config = json.load(config_file)
        driver = db_config['DriverWindows'] if platform.system() == 'Windows' else db_config['DriverMac']
        connection_string_odbc  = (
                                f"Driver={{{driver}}};"
                                f"Server={db_config['Server']};"
                                f"Database={db_config['Database']};"
                                f"UID={db_config['UID']};"
                                f"PWD={db_config['PWD']};"
                            )
except FileNotFoundError:
    print(f"Error: {db_config_path} not found.")


connection_string_alchemy = "mssql+pyodbc:///?odbc_connect=" + connection_string_odbc
engine = create_engine(connection_string_alchemy)
connection = pyodbc.connect(connection_string_odbc)
cursor = connection.cursor()


def get_hour(schedule_id):
    query = f"select Hours from Schedule where Id = {schedule_id}"

    cursor.execute(query)
    return cursor.fetchone()[0]


def fetch_data(schedule_id):  
    query = f"""
    SELECT S.Id as SubjectId, S.SuggestedHours, S.HoursPerSem
    FROM Subject S
    WHERE S.Id IN (select SubjectId from ScheduleRow where ScheduleId = {schedule_id})
    """
    
    data = pd.read_sql_query(query, engine)
    
    subject_ids = data['SubjectId'].values
    suggested_hours = data['SuggestedHours'].values
    current_hours = data['HoursPerSem'].values
    
    return subject_ids, suggested_hours, current_hours


def objective(x, current_hours):
    return np.sum((x - current_hours) ** 2)


def constraint(x, total_hours):
    return np.sum(x) - total_hours


def optimize_hours(schedule_id, total_hours):
    subject_ids_array, suggested_hours, current_hours = fetch_data(schedule_id)
    initial_guess = suggested_hours + current_hours
    
    bounds = [(0, None)] * len(suggested_hours)
    constraints = [{'type': 'eq', 'fun': constraint, 'args': (total_hours,)}]

    result = minimize(objective, initial_guess, args=(current_hours,), bounds=bounds, constraints=constraints)
    
    optimized_hours = np.round(result.x, 2)
    
    optimized_hours_dict = dict(zip(subject_ids_array, optimized_hours))
    
    return optimized_hours_dict


def update_table(schedule_id, hours_dict):
    for id, hour in hours_dict.items():
        query = """
                UPDATE ScheduleRow
                SET CalculatedHours = ?
                where ScheduleId = ?
                and SubjectId = ?
        """

        try:
            cursor.execute(query, hour, int(schedule_id), int(id))
            cursor.commit()
    
        except Exception as e:
            print(f"An error occurred: {e}")


if __name__ == '__main__':
    args = sys.argv[1:]
    
    schedule_id = int(args[0])
    total_hours = int(get_hour(schedule_id))
    
    optimized_hours_dict = optimize_hours(schedule_id, total_hours)

    update_table(schedule_id, optimized_hours_dict)

    optimized_hours_dict_converted = {int(k): v for k, v in optimized_hours_dict.items()}
    optimized_hours_json = json.dumps(optimized_hours_dict_converted)

    print(optimized_hours_json, end='')

    engine.dispose()

