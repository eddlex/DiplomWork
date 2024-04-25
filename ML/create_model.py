import pandas as pd
import matplotlib.pyplot as plt
from sqlalchemy import create_engine
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_squared_error
import seaborn as sns
import numpy as np
import pickle
import json
import platform

db_config_path = __file__.replace('create_model.py', 'DBconn.json') 

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

model_file = "model.pkl"  


def get_data():
    sql_query = """
        SELECT R.FormIdentificationId, S.Title, R.Value, S.HoursPerSem, S.DepartmentId
        FROM Rating R
        JOIN dbo.FormIdentification FI ON R.FormIdentificationId = FI.Id
        JOIN dbo.FormRow FR ON R.FormRowId = FR.Id
        JOIN dbo.Form F ON F.Id = FR.FormId
        JOIN Subject S ON S.Id = FR.SubjectId
    """
    data = pd.read_sql_query(sql_query, engine)
    return data


def get_original_title(row):
    # Map dummy variables back to original categorical values
    title_columns = [col for col in X.columns if col.startswith('Title_')]

    for col in title_columns:
        if row[col] == 1:
            return col[len('Title_'):]


def save_model(model):
    with open(model_file, 'wb') as file:  
        pickle.dump(model, file)


def filter_data(data):
    grouped = data.groupby('FormIdentificationId')['Value']

    agg_results = grouped.agg(['min', 'median', 'max'])
    agg_results['all_equal'] = (agg_results['min'] == agg_results['median']) & (agg_results['median'] == agg_results['max'])
    groups_to_keep = agg_results.index[~agg_results['all_equal']]

    return data[data['FormIdentificationId'].isin(groups_to_keep)]


if __name__ == '__main__': 
    data1 = get_data()
    data = filter_data(data1)
    # Encoding categorical variables using one-hot encoding
    data = pd.get_dummies(data, columns=['Title'])

    X = data.drop(columns=['HoursPerSem', 'FormIdentificationId']).sort_index(axis=1)  # Features
    y = data['HoursPerSem']  # Target variable

    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=69)

    with open('shared_data.pkl', 'wb') as f:
        pickle.dump(X_train, f)

    model = LinearRegression()
    model.fit(X_train, y_train)

    save_model(model)

    train_predictions = model.predict(X_train)
    test_predictions = model.predict(X_test)

    train_rmse = mean_squared_error(y_train, train_predictions).round(3)
    test_rmse = mean_squared_error(y_test, test_predictions).round(3)

    print(f"Train RMSE: {train_rmse}")
    print(f"Test RMSE: {test_rmse}")

    engine.dispose()


