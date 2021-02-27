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