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


def make_training_matrices(full_animal_dict):
    """Convert user's data from Unity into numpy matrices in the same shapes as generated test data."""
    size = 0
    for key in full_animal_dict.keys():
        size += len(full_animal_dict[key])

    feature_matrix = np.zeros(shape=(size, 4))
    class_matrix = np.zeros(shape=(size,))

    idx = 0
    for key in full_animal_dict.keys():
        for animal in full_animal_dict[key]:
            feature_matrix[idx] = np.array([animal[0], animal[1],
                                            animal[2], animal[3]])
            class_matrix[idx] = int(key / 3.0)
            idx += 1

    return (feature_matrix, class_matrix)


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


def run_algorithm(training_matrices, classifier, **params):
    test_matrices = generate_test_data(5000)
    acc = test_model(make_classifier(
        classifier, params=params), training_matrices, test_matrices)
    return acc


def create_plot(classifier, k_space, n_space, accuracies):
    """Return an iamge of a plot of average accuracy across the appropriate varied parameter."""
    pass


def run_process(full_animal_dict, classifier):
    training_matrices = make_training_matrices(full_animal_dict)
    training_size = len(training_matrices[1])
    k_space = np.linspace(1, training_size - 1, num=10, dtype=np.int32)
    n_space = np.array([50, 75, 100, 125, 150, 175, 200, 225, 250, 275])
    accuracies = np.zeros(shape=(10,))

    for i in range(10):
        average_acc = 0
        for _ in range(3):
            average_acc += run_algorithm(training_matrices,
                                         classifier, k=k_space[i], n=n_space[i])
        average_acc /= 3
        accuracies[i] = average_acc
    create_plot(classifier, k_space, n_space, accuracies)
