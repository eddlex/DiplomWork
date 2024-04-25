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
 
shared_data_path = __file__.replace('evaluate.py', 'shared_data.pkl')
model_path = __file__.replace('evaluate.py', 'model.pkl')

with open(shared_data_path, 'rb') as f: 
    X_train = pickle.load(f)

connection_string = (
    "mssql+pyodbc:///?odbc_connect="
    "Driver={ODBC Driver 18 for SQL Server};"
    "Server=SQL5113.site4now.net;"
    "Database=db_aa7bdf_diplom;"
    'UID=db_aa7bdf_diplom_admin;'
    'PWD=123123Aa;'
)

connection_string_odbc = (
    """
    Driver={ODBC Driver 18 for SQL Server};
    Server=SQL5113.site4now.net;
    Database=db_aa7bdf_diplom;
    UID=db_aa7bdf_diplom_admin;
    PWD=123123Aa;
"""
   
)

connection = pyodbc.connect(connection_string_odbc)
select_cursor = connection.cursor()

engine = create_engine(connection_string)


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


def get_original_title(row, eval_data1):
    title_columns = [col for col in eval_data1.columns if col.startswith('Title_')]

    for col in title_columns:
        if row[col] == 1:
            return col[len('Title_'):]


def get_figure():
    pass
    # # Scatter plot of actual vs. predicted values
    # plt.figure(figsize=(10, 6))
    # sns.scatterplot(x=test_results['Actual'], y=test_results['Predicted'])
    # plt.xlabel('Actual Hours Per Semester')
    # plt.ylabel('Predicted Hours Per Semester')
    # plt.title('Actual vs. Predicted Hours Per Semester')
    # plt.show()

    # # Histogram or density plot of residuals
    # residuals = test_results['Actual'] - test_results['Predicted']
    # plt.figure(figsize=(8, 6))
    # sns.histplot(residuals, kde=True)
    # plt.xlabel('Residuals')
    # plt.ylabel('Frequency')
    # plt.title('Histogram of Residuals')
    # plt.show()


def model_predict(features):
    with open(model_path, 'rb') as file:  
        model = pickle.load(file)

    y_predict = model.predict(features)

    return y_predict


def insert_hour(sub_id, value):
    sql_query = "UPDATE Subject SET SuggestedHours = ? WHERE Id = ? " 

    try:
        select_cursor.execute(sql_query, value, int(sub_id))
        select_cursor.commit()
        return True
    
    except Exception as e:
        print(f"An error occurred: {e}")
        return False


def evaluate_model(sbj_id=None):
    eval_data = get_predict_data(sbj_id)
    eval_data = pd.get_dummies(eval_data, columns=['Title'])
    features = eval_data.drop(columns=['HoursPerSem']).sort_index(axis=1)
    yres = eval_data['HoursPerSem']

    missing_cols = set(X_train.columns) - set(features.columns)
    for c in missing_cols:
        features[c] = 0 # change to mean or median

    features = features[X_train.columns] 

    res = model_predict(features)
    # test_results = pd.DataFrame({'Actual': yres, 'Predicted': res.round(1)})
    # test_results['SubjectTitle'] = features.apply(get_original_title, args=(eval_data,), axis=1)
    # test_results['SubjectTitle'] = test_results['SubjectTitle'].astype(str)
    # #test_results['ChangeHours'] = evaluate_hours_change(yres, res)
    # #test_results[['SubjectTitle', 'Actual', 'Predicted', 'ChangeHours']].iloc[:1].to_csv('results.csv', index=False)
    # #test_results[['SubjectTitle', 'Actual', 'Predicted']].iloc[:1].to_csv('results.csv', index=False)
    # test_results['MeanSqrError'] = mean_squared_error(yres, res).round(3)
    
    # # Convert the first row of the DataFrame to a dictionary for returning
    # res_dict = test_results[['SubjectTitle', 'Actual', 'Predicted', 'MeanSqrError']].iloc[0].to_dict()
    # # res_rmse = mean_squared_error(yres, res).round(3)
    # # print(f"Train RMSE: {res_rmse}")
    # return res_dict
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
    # args = sys.argv[1:]    
    # ids = list(map(int, args[0:]))
    #ids = list(map(int, sys.argv[1:] ))

    ids = get_data()
    ids = ids['Id'].values
    suggested_hours = evaluate_subjects(ids)

    suggested_hours_converted = {int(k): v for k, v in suggested_hours.items()}
    suggested_hours_json = json.dumps(suggested_hours_converted)

    print(suggested_hours_json, end='')

    engine.dispose()
