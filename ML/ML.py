import pandas as pd
import matplotlib.pyplot as plt
from sqlalchemy import create_engine
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_squared_error
import seaborn as sns
import numpy as np


connection_string = (
    "mssql+pyodbc:///?odbc_connect="
    "Driver={SQL Server};"
    "Server=SQL8005.site4now.net;"
    "Database=db_aa56f4_diplom;"
    'UID=db_aa56f4_diplom_admin;'
    'PWD=123123Aa;'
)

engine = create_engine(connection_string)

sql_query = """
    SELECT S.Title, R.Value, S.HoursPerSem
    FROM Rating R
    JOIN dbo.FormIdentification FI ON R.FormIdentificationId = FI.Id
    JOIN dbo.FormRow FR ON R.FormRowId = FR.Id
    JOIN dbo.Form F ON F.Id = FR.FormId
    JOIN Subject S ON S.Id = FR.SubjectId
"""

data = pd.read_sql_query(sql_query, engine)
engine.dispose()

# Data preprocessing

# Drop any rows with missing values
#data.dropna(inplace=True)

# Encode categorical variables using one-hot encoding
data = pd.get_dummies(data, columns=['Title'])

# Split the data into features (X) and target variable (y)
X = data.drop(columns=['HoursPerSem'])  # Features
y = data['HoursPerSem']  # Target variable

# Split the data into training and testing sets
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Model training
model = LinearRegression()
model.fit(X_train, y_train)

# Model evaluation
train_predictions = model.predict(X_train)
test_predictions = model.predict(X_test)

train_rmse = mean_squared_error(y_train, train_predictions).round(3)
test_rmse = mean_squared_error(y_test, test_predictions).round(3)

# Concatenate predicted values with actual values
train_results = pd.DataFrame({'Actual': y_train, 'Predicted': train_predictions.round(1)})
test_results = pd.DataFrame({'Actual': y_test, 'Predicted': test_predictions.round(1)})

# Map dummy variables back to original categorical values
title_columns = [col for col in X.columns if col.startswith('Title_')]

def get_original_title(row):
    for col in title_columns:
        if row[col] == 1:
            return col[len('Title_'):]


train_results['SubjectTitle'] = X_train.apply(get_original_title, axis=1)
test_results['SubjectTitle'] = X_test.apply(get_original_title, axis=1)

test_results['ChangeHours'] = np.where(y_test - test_predictions >= 2, 'Reduce hours',
                              np.where(test_predictions - y_test >= 2, 'Add hours', 
                              'ok'))

train_results['ChangeHours'] = np.where(y_train - train_predictions >= 2, 'Reduce hours',
                               np.where(train_predictions - y_train >= 2, 'Add hours', 
                               'ok'))


print("Training Set Results:")
#print(train_results[['SubjectTitle', 'Actual', 'Predicted']].to_string())
train_results[['SubjectTitle', 'Actual', 'Predicted', 'ChangeHours']].to_csv('train_results.csv', index=False)
print(f"Train RMSE: {train_rmse}")

print("\nTesting Set Results:")
#print(test_results[['SubjectTitle', 'Actual', 'Predicted']].to_string())
test_results[['SubjectTitle', 'Actual', 'Predicted', 'ChangeHours']].to_csv('test_results.csv', index=False)
print(f"Test RMSE: {test_rmse}")


# print("Training Set Results:")
# print(train_results)
# print(f"Train RMSE: {train_rmse}")

# print("\nTesting Set Results:")
# print(test_results)
# print(f"Test RMSE: {test_rmse}")

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