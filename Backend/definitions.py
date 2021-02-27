class Animal:
    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]

    def get_weight(self):
        return self.weight

    def get_red(self):
        return self.color[0]

    def get_green(self):
        return self.color[1]

    def get_blue(self):
        return self.color[2]


class Mammal(Animal):
    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class ReptileAmph(Animal):
    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Bird(Animal):
    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Monkey(Mammal):
    key = 0
    colors = []

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Lion(Mammal):
    key = 1
    colors = []

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Hippo(Mammal):
    key = 2
    colors = []

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Crocodile(ReptileAmph):
    key = 3
    colors = []

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Snake(ReptileAmph):
    key = 4
    colors = []

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Frog(ReptileAmph):
    key = 5
    colors = []

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Parrot(Bird):
    key = 6
    colors = []

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Duck(Bird):
    key = 7
    colors = []

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Seagull(Bird):
    key = 8
    colors = []

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]
