# mappings is a dictionary that maps key values to function pointers
# these functions create randomly generated Animal objects
# the animal generated corresponds to the key value
from definitions import mappings

# Import numpy for vectors and matrices
import numpy as np

# Import classifier algorithms
from sklearn.neighbors import KNeighborsClassifier
from sklearn.ensemble import RandomForestClassifier

# Import evaluation tools
from sklearn.metrics import accuracy_score

# a list of all the available algorithms
classifiers = [KNeighborsClassifier, RandomForestClassifier]


def generate_test_data(count):
    """Randomly generate test animals and populate matrices with input and output vectors."""
    feature_matrix = np.zeros(shape=(count, 4))
    class_matrix = np.zeros(shape=(count,))
    for i in range(count):
        choice = np.random.choice(list(mappings.keys()))
        animal = mappings[choice]()

        feature_matrix[i] = np.array([animal.get_weight(), animal.get_red(),
                                      animal.get_green(), animal.get_blue()])
        # the floor of the animal key divided by 3 gives the class number for Mammal, ReptileAmph, or Bird
        class_matrix[i] = int(choice / 3.0)
    return (feature_matrix, class_matrix)


def make_classifier(classifier_type, **params):
    """Create classifier with appropriate parameters passed in as keyword arguments."""
    classifier = None
    if classifier_type == KNeighborsClassifier:
        classifier = KNeighborsClassifier(n_neighbors=params['k'])
    elif classifier_type == RandomForestClassifier:
        classifier = RandomForestClassifier(
            n_estimators=params['n'], max_depth=params['d'])  # may revisit these parameters
    return classifier


def test_model(classifier, training_matrices, test_matrices):
    """Compute accuracy of a given classifier on particular test data."""
    classifier.fit(training_matrices[0], training_matrices[1])
    predictions = classifier.predict(test_matrices[0])
    accuracy = accuracy_score(test_matrices[1], predictions)
    return accuracy
