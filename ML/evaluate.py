import json
import pandas as pd
import matplotlib.pyplot as plt
from sqlalchemy import create_engine
from sqlalchemy.sql import text
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_squared_error
import seaborn as sns
import numpy as np
import pickle
import pyodbc 
import platform

shared_data_path = __file__.replace('evaluate.py', 'shared_data.pkl')
model_path = __file__.replace('evaluate.py', 'model.pkl')
db_config_path = __file__.replace('evaluate.py', 'DBconn.json') 


try:
    with open(shared_data_path, 'rb') as f: 
        X_train = pickle.load(f)
except FileNotFoundError:
    print(f"Error: {shared_data_path} not found.")

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


connection = pyodbc.connect(connection_string_odbc)
cursor = connection.cursor()

connection_string_alchemy = "mssql+pyodbc:///?odbc_connect=" + connection_string_odbc
engine = create_engine(connection_string_alchemy)


def get_predict_data(subject_id=None): 
    sql_query = """
        SELECT S.Title, R.Value, S.HoursPerSem, S.DepartmentId
        FROM Rating R
        JOIN dbo.FormIdentification FI ON R.FormIdentificationId = FI.Id
        JOIN dbo.FormRow FR ON R.FormRowId = FR.Id
        JOIN dbo.Form F ON F.Id = FR.FormId
        JOIN Subject S ON S.Id = FR.SubjectId
    """

    if subject_id:
        sql_query = sql_query + f" where S.Id = {subject_id} "


    data = pd.read_sql_query(sql_query, engine)
    return data


def get_data(): 
    sql_query = """
        SELECT S.Id
        FROM Rating R
        JOIN dbo.FormIdentification FI ON R.FormIdentificationId = FI.Id
        JOIN dbo.FormRow FR ON R.FormRowId = FR.Id
        JOIN dbo.Form F ON F.Id = FR.FormId
        JOIN Subject S ON S.Id = FR.SubjectId
    """

    data = pd.read_sql_query(sql_query, engine)
    return data


def model_predict(features):
    try:
        with open(model_path, 'rb') as file: 
            model = pickle.load(file)
    except FileNotFoundError:
        print(f"Error: {model_path} not found.")

    y_predict = model.predict(features)

    return y_predict


def insert_hour(sub_id, value):
    sql_query = "UPDATE Subject SET SuggestedHours = ? WHERE Id = ? " 

    try:
        cursor.execute(sql_query, value, int(sub_id))
        cursor.commit()
        return True
    
    except Exception as e:
        print(f"An error occurred: {e}")
        return False


def evaluate_model(sbj_id=None):
    eval_data = get_predict_data(sbj_id)
    eval_data = pd.get_dummies(eval_data, columns=['Title'])
    features = eval_data.drop(columns=['HoursPerSem']).sort_index(axis=1)
    # yres = eval_data['HoursPerSem']

    missing_cols = set(X_train.columns) - set(features.columns)
    for c in missing_cols:
        features[c] = 0 # change to mean or median

    features = features[X_train.columns] 

    res = model_predict(features)
    rounded_predictions = res.round(1)
    mean_prediction = rounded_predictions.mean().round(1)

    return mean_prediction


def evaluate_subjects(subject_ids):
    results_dict = {}
    
    for sbj_id in subject_ids:
        hour = evaluate_model(sbj_id)
        results_dict[sbj_id] = hour
        insert_hour(sbj_id, hour)
 
    return results_dict


if __name__ == '__main__':
    ids = get_data()
    ids = ids['Id'].values
    suggested_hours = evaluate_subjects(ids)

    suggested_hours_converted = {int(k): v for k, v in suggested_hours.items()}
    suggested_hours_json = json.dumps(suggested_hours_converted)

    print(suggested_hours_json, end='')

    engine.dispose()
    connection.close()
