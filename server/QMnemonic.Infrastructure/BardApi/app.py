from flask import Flask, request
from bardapi import Bard

app = Flask(__name__)

conditions = "."
token = "dQgeYEUr1HtYnq8iOOyHyEWY1EYj7v3GIL42M3ud_nU6xIQCkege6L8GBuxLAVcfafqKRg."

bard = Bard(token=token)

@app.route('/')
def hello():
    return 'Hello from the microservice!'

@app.route('/generate', methods=['GET', 'POST'])
def generator():
    if request.method == 'POST':
        try:
            input_text = request.json['text'] 
            conditions = input_text
        except KeyError:
            return "Błąd: Brak klucza 'text' w danych wejściowych.", 400
    
    return bard.get_answer(conditions)['content']

if __name__ == '__main__':
    app.run(port=5000)
