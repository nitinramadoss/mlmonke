import classification


def main():
    train = classification.generate_test_data(15)
    test = classification.generate_test_data(5000)
    acc = classification.test_model(classification.make_classifier(
        classification.KNeighborsClassifier, k=1), train, test)
    return acc


score = 0
for i in range(10):
    score += main()
score /= 10
print(score)
