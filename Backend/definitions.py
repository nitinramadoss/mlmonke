# Import numpy for random generation over distribution
import numpy as np


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
    colors = ['brown', 'red', 'orange', 'yellow', 'white', 'grey', 'black']

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Lion(Mammal):
    key = 1
    colors = ['yellow', 'brown', 'orange', 'white']

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Hippo(Mammal):
    key = 2
    colors = ['brown', 'grey']

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Crocodile(ReptileAmph):
    key = 3
    colors = ['grey', 'black', 'dark green', 'brown']

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Snake(ReptileAmph):
    key = 4
    colors = ['yellow', 'dark green', 'brown', 'black']

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Frog(ReptileAmph):
    key = 5
    colors = ['red', 'yellow', 'orange', 'dark green', 'dark blue',
              'light green', 'light blue', 'purple', 'pink', 'white', 'grey', 'black']

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Parrot(Bird):
    key = 6
    colors = ['red', 'yellow', 'orange', 'dark green', 'dark blue',
              'light green', 'light blue', 'purple', 'pink', 'white', 'grey', 'black']

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Duck(Bird):
    key = 7
    colors = ['white', 'yellow']

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


class Seagull(Bird):
    key = 8
    colors = ['white', 'grey']

    def __init__(self, attributes):
        self.weight = attributes[0]
        self.color = attributes[1]


def make_animal(weight_mean, weight_sd, r_mean, g_mean, b_mean, color_sd, grey_scale=False):
    weight = 0
    color = (0, 0, 0)

    while(weight <= 0 or color[0] < 0 or color[0] > 255 or color[1] < 0 or color[1] > 255 or color[2] < 0 or color[2] > 255):
        # randomly generate weight along normal distribution
        weight = np.random.normal(loc=weight_mean, scale=weight_sd)
        if not grey_scale:
            # randomly generate color along normal distribution
            color = (np.random.normal(loc=r_mean, scale=color_sd), np.random.normal(
                loc=g_mean, scale=color_sd), np.random.normal(loc=b_mean, scale=color_sd))
        else:
            col_val = np.random.normal(loc=r_mean, scale=color_sd)
            # make R = G = B to produce grey color
            color = (col_val, col_val, col_val)
    return (weight, color)


def make_monkey():
    return Monkey(make_animal(50, 22, 147, 82, 32, 20))


def make_lion():
    return Lion(make_animal(350, 50, 222, 204, 156, 5))


def make_hippo():
    return Hippo(make_animal(3500, 250, 100, 100, 100, 50, grey_scale=True))


def make_crocodile():
    return Crocodile(make_animal(1000, 500, 67, 96, 0, 15))


def make_snake():
    return Snake(make_animal(60, 30, 67, 96, 0, 15))


def make_frog():
    return Frog(make_animal(0.5, 0.5, 150, 150, 150, 100))


def make_parrot():
    return Parrot(make_animal(3, 2, 150, 150, 150, 100))


def make_duck():
    return Duck(make_animal(2.5, 0.5, 255, 221, 89, 5))


def make_seagull():
    return Seagull(make_animal(2, 1, 225, 225, 225, 25, grey_scale=True))


mappings = {
    0: make_monkey,
    1: make_lion,
    2: make_hippo,
    3: make_crocodile,
    4: make_snake,
    5: make_frog,
    6: make_parrot,
    7: make_duck,
    8: make_seagull
}

color_rgbs = {
    'brown': (60, 46, 33),
    'red': (128, 0, 0),
    'orange': (255, 165, 0),
    'yellow': (255, 255, 102),
    'white': (249, 249, 249),
    'grey': (128, 128, 128),
    'black': (63, 63, 63),
    'dark green': (0, 153, 0),
    'dark blue': (51, 51, 255),
    'light green': (0, 204, 0),
    'light blue': (0, 204, 204),
    'purple': (153, 51, 255),
    'pink': (255, 153, 255),

}
