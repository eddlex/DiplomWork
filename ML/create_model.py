import pandas as pd
import matplotlib.pyplot as plt
from sqlalchemy import create_engine
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_squared_error
import seaborn as sns
import numpy as np
import pickle


connection_string = (
    "mssql+pyodbc:///?odbc_connect="
    "Driver={SQL Server};"
    "Server=SQL5113.site4now.net;"
    "Database=db_aa7bdf_diplom;"
    'UID=db_aa7bdf_diplom_admin;'
    'PWD=123123Aa;'
)
engine = create_engine(connection_string)
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

# def get_predict_data(subject_id=None): 
#     sql_query = """
#         SELECT S.Title, R.Value, S.HoursPerSem, S.DepartmentId
#         FROM Rating R
#         JOIN dbo.FormIdentification FI ON R.FormIdentificationId = FI.Id
#         JOIN dbo.FormRow FR ON R.FormRowId = FR.Id
#         JOIN dbo.Form F ON F.Id = FR.FormId
#         JOIN Subject S ON S.Id = FR.SubjectId
#     """
#     if subject_id:
#         sql_query = sql_query + f" where S.Id = {subject_id}"

#     data = pd.read_sql_query(sql_query, engine)
#     return data

# def process_data():
    pass
    # Data preprocessing

    # Drop any rows with missing values
    #data.dropna(inplace=True)

def get_original_title(row):
    # Map dummy variables back to original categorical values
    title_columns = [col for col in X.columns if col.startswith('Title_')]

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

    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

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
    # train_results = pd.DataFrame({'Actual': y_train, 'Predicted': train_predictions.round(1)})
    # test_results = pd.DataFrame({'Actual': y_test, 'Predicted': test_predictions.round(1)})

    # train_results['SubjectTitle'] = X_train.apply(get_original_title, axis=1)
    # test_results['SubjectTitle'] = X_test.apply(get_original_title, axis=1)

    engine.dispose()


# print("\nTraining Set Results:")
# train_results[['SubjectTitle', 'Actual', 'Predicted', 'ChangeHours']].to_csv('train_results.csv', index=False)
# print(f"Train RMSE: {train_rmse}")

# print("\nTesting Set Results:")
# test_results[['SubjectTitle', 'Actual', 'Predicted', 'ChangeHours']].to_csv('test_results.csv', index=False)
# print(f"Test RMSE: {test_rmse}")

