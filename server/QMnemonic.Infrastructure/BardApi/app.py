from flask import Flask, request
from bardapi import Bard

app = Flask(__name__)

conditions = "."




@app.route('/')
def hello():
    return 'Hello from the microservice!'

@app.route('/generate', methods=['GET', 'POST'])
def generator():
    if request.method == 'POST':
        try:
            input_text = request.json['prompt']+request.json['content']
            bard = Bard(token=request.json['key'])
        except KeyError:
            return "Błąd w danych wejściowych.", 400
    
    return bard.get_answer(input_text)['content']

if __name__ == '__main__':
    app.run(port=5000)
