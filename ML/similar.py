import sys
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.metrics.pairwise import cosine_similarity
import pyodbc
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
    query = "SELECT Value, Id FROM Suggestion"
    
    cursor.execute(query)
    return cursor.fetchall()


def get_similars(suggestions, threshold, suggestion_id=None):
    sentences = [row[0] for row in suggestions]
    ids = [row[1] for row in suggestions]
    
    # Convert sentences into TF-IDF vectors
    vectorizer = TfidfVectorizer()
    tfidf_matrix = vectorizer.fit_transform(sentences)
    
    similarity_matrix = cosine_similarity(tfidf_matrix)
    
    similar_sentences = []
    
    if suggestion_id:
        index_of_given = ids.index(suggestion_id)
        
        for i in range(len(sentences)):
            if i != index_of_given and similarity_matrix[index_of_given][i] > threshold:
                similar_sentences.append(ids[i])

    else:
        for i in range(len(sentences) - 1):
            for j in range(i + 1, len(sentences)):
                if similarity_matrix[i][j] > threshold:
                    similar_sentences.append(ids[i])
                    similar_sentences.append(ids[j])
    
    return list(set(similar_sentences))


# python "c:\\Users\\Irin\\Desktop\\diplom_ML\\similar.py" 0.5 3 
# python "c:\\Users\\Irin\\Desktop\\diplom_ML\\similar.py" 0.5 
# first argument is threshold for similarity and is required
# second argument is id of suggestion, if provided will return the lsit of similars, otherwise returns all similar suggestions
if __name__ == '__main__':
    args = sys.argv[1:]
    
    threshold = float(args[0])
    suggestion_id = None
    
    if len(args) == 2:
        suggestion_id = int(args[1])
    
    suggestions = get_suggestions()
    similars = get_similars(suggestions, threshold, suggestion_id)
    
    similars_json = json.dumps(similars)
    
    cursor.close()
    connection.close()
    
    print(similars_json, end='')
