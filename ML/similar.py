import sys
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.metrics.pairwise import cosine_similarity
import pyodbc
import sqlalchemy
import json
import platform

sys.stdout.reconfigure(encoding='utf-8')
db_config_path = __file__.replace('similar.py', 'DBconn.json') 

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

def get_suggestions():
    query = "SELECT Value, Id, FormIdentificationId FROM Suggestion"
    cursor.execute(query)

    # sentences = [row[0] for row in cursor.fetchall()]
    # sentences = [sentence.lower() for sentence in sentences]

    return cursor.fetchall()


def get_similars(suggestions, threshold):
    vectorizer = TfidfVectorizer()
    sentences = [row[0] for row in suggestions]
    # Convert sentences into TF-IDF vectors
    tfidf_matrix = vectorizer.fit_transform(sentences)
    similarity_matrix = cosine_similarity(tfidf_matrix)

    similar_sentences = {}

    for i in range(len(sentences) - 1):
        for j in range(i + 1, len(sentences)):
            if similarity_matrix[i][j] > threshold:
                id_i = suggestions[i][1]  
                id_j = suggestions[j][1]  
            
                similar_sentences[id_i] = suggestions[i][2], suggestions[i][0]
                similar_sentences[id_j] = suggestions[j][2], suggestions[j][0]

    return similar_sentences


if __name__ == '__main__':
    # args = sys.argv[1:]
    
    # threshold = float(args[0])
    # if(len(args) == 2):
    #     suggestion_id = int(args[1])
    
    suggestions = get_suggestions()
    # sentences = [row[0] for row in suggestions]
    # sentences = [sentence.lower() for sentence in sentences]
    similars = get_similars(suggestions, 0.5)

    similars = {int(k): v for k, v in similars.items()}
    similars_json = json.dumps(similars)

    cursor.close()
    connection.close()

    print(similars_json, end='')


