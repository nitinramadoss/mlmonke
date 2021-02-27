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
