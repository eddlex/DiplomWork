# import numpy as np
# from scipy.optimize import minimize
# from sqlalchemy import create_engine

# connection_string = (
#     "mssql+pyodbc:///?odbc_connect="
#     "Driver={SQL Server};"
#     "Server=SQL5113.site4now.net;"
#     "Database=db_aa7bdf_diplom;"
#     'UID=db_aa7bdf_diplom_admin;'
#     'PWD=123123Aa;'
# )
# engine = create_engine(connection_string)

# # Suggested hours per semester for each subject (from your regression model)
# suggested_hours = np.array([30, 20, 40, 25])  # Example values, replace with your data

# # Current hours allocated to each subject
# current_hours = np.array([15, 10, 20, 12])  # Example values, replace with your data

# # Total available hours for the semester
# total_hours = 100  # Example value, replace with your data

# # Define objective function to minimize (difference between suggested and actual hours)
# def objective(x):
#     return np.sum((x - current_hours) ** 2)

# # Define constraint function (total hours should be equal to total_hours)
# def constraint(x):
#     return np.sum(x) - total_hours

# # Initial guess for the hours allocation (optional)
# initial_guess = suggested_hours + current_hours

# # Define bounds for optimization (hours should be non-negative)
# bounds = [(0, None)] * len(suggested_hours)

# # Define constraints
# constraints = [{'type': 'eq', 'fun': constraint}]

# # Perform optimization
# result = minimize(objective, initial_guess, bounds=bounds, constraints=constraints)

# # Extract optimized hours allocation
# optimized_hours = result.x

# print("Optimized hours allocation:", optimized_hours)


import json
import numpy as np
from scipy.optimize import minimize
from sqlalchemy import create_engine
import pandas as pd
import sys

connection_string = (
    "mssql+pyodbc:///?odbc_connect="
    "Driver={SQL Server};"
    "Server=SQL5113.site4now.net;"
    "Database=db_aa7bdf_diplom;"
    'UID=db_aa7bdf_diplom_admin;'
    'PWD=123123Aa;'
)

engine = create_engine(connection_string)

def fetch_data(subject_ids):
    # Convert list of subject IDs to a string for the SQL query
    subject_ids_str = ','.join(map(str, subject_ids))
    
    # SQL query to fetch suggested and current hours for the given subject IDs
    query = f"""
    SELECT S.Id as SubjectId, S.SuggestedHours, S.HoursPerSem
    FROM Subject S
    WHERE S.Id IN ({subject_ids_str})
    """
    
    # Fetch data from the database
    data = pd.read_sql_query(query, engine)
    
    # Extract subject IDs, suggested, and current hours as numpy arrays
    subject_ids = data['SubjectId'].values
    suggested_hours = data['SuggestedHours'].values
    current_hours = data['HoursPerSem'].values
    
    return subject_ids, suggested_hours, current_hours

# Define objective function to minimize (difference between suggested and actual hours)
def objective(x, current_hours):
    return np.sum((x - current_hours) ** 2)

# Define constraint function (total hours should be equal to total_hours)
def constraint(x, total_hours):
    return np.sum(x) - total_hours

# Function to optimize hours allocation and return a dictionary
def optimize_hours(subject_ids, total_hours):
    # Fetch data from the database
    subject_ids_array, suggested_hours, current_hours = fetch_data(subject_ids)
    
    # Initial guess for the hours allocation
    initial_guess = suggested_hours + current_hours
    
    # Define bounds for optimization (hours should be non-negative)
    bounds = [(0, None)] * len(suggested_hours)
    
    # Define constraints
    constraints = [{'type': 'eq', 'fun': constraint, 'args': (total_hours,)}]
    
    # Perform optimization
    result = minimize(objective, initial_guess, args=(current_hours,), bounds=bounds, constraints=constraints)
    
    # Extract optimized hours allocation
    optimized_hours = np.round(result.x, 2)
    
    # Create a dictionary mapping subject IDs to optimized hours
    optimized_hours_dict = dict(zip(subject_ids_array, optimized_hours))
    
    return optimized_hours_dict


if __name__ == '__main__':
    # Get command line arguments
    args = sys.argv[1:]
    
    # Parse total hours from the first argument
    total_hours = int(args[0])
    
    # Parse subject IDs from the remaining arguments
    subject_ids = list(map(int, args[1:]))
    
    # Optimize hours allocation for the given subject IDs and total hours
    optimized_hours_dict = optimize_hours(subject_ids, total_hours)
    #return json.dumps(subject_ids)
    optimized_hours_dict_converted = {int(k): v for k, v in optimized_hours_dict.items()}

    optimized_hours_json = json.dumps(optimized_hours_dict_converted)

    print(optimized_hours_json, end='')

    engine.dispose()

# subject_ids = [1, 2, 3, 4]  # Example subject IDs
# total_hours = 100  # Example total hours

# # Optimize hours allocation for the given subject IDs and total hours
# optimized_hours_dict = optimize_hours(subject_ids, total_hours)

# # Return optimized hours allocation dictionary
# print("Optimized hours allocation:", optimized_hours_dict)

# engine.dispose()