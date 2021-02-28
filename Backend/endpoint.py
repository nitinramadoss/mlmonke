from flask import Flask, jsonify, request
from flask_cors import CORS
import json
import requests

from generateSamples import generate
from classification import run_process, classifiers

# Import plotting tools
from matplotlib.figure import Figure

# Import image handling tools
import base64
import io

app = Flask(__name__)
CORS(app)


def create_plot(classifier, k_space, n_space, accuracies):
    """Return an iamge of a plot of average accuracy across the appropriate varied parameter."""
    x = None

    if classifier == classifiers[0]:
        x = k_space
    elif classifiers == classifiers[1]:
        x = n_space

    fig = Figure()
    ax = fig.add_subplot(111)
    print(x)
    ax.plot(x, accuracies, 'b')

    # p = plt.plot(x, accuracies, 'b')

    # if classifier == classifiers[0]:
    #     plt.xlabel('K, Number of Nearest Neighbors')
    #     plt.title('Accuracy of KNN Classifier')
    # elif classifiers == classifiers[1]:
    #     plt.xlabel('N, Number of Decision Trees')
    #     plt.title('Accuracy of Random Forest Classifier')

    # plt.ylabel('Average Prediction Accuracy')

    img_bytes = io.BytesIO()
    fig.savefig(img_bytes,  format='png')
    img_bytes.seek(0)
    encoded_hash = base64.b64encode(img_bytes.read())
    return encoded_hash


@app.route('/generate', methods=['GET'])
def create_data():
    data = generate(75)
    return jsonify(data), 200


@app.route('/results', methods=['POST'])
def create_results():
    data = request.json('data', None)
    model_choice = int(request.json.get('model', None))
    classifier = classifiers[model_choice]
    k_space, n_space, accuracies = run_process(data, classifier)

    img = create_plot(classifier, k_space, n_space, accuracies)
    return jsonify(img=img.decode('utf-8')), 200


if __name__ == '__main__':
    app.run()
