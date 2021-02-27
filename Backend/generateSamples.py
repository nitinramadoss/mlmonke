# mappings is a dictionary that maps key values to function pointers
# these functions create randomly generated Animal objects
# the animal generated corresponds to the key value
# color_rgbs is a dictionary that maps string color names to rgb tuples
from definitions import mappings, color_rgbs
import numpy as np


def generate_animals(animal_choice, count):
    """Make a list of Animal objects with randomly generated properties."""
    animals = []
    for _ in range(count):
        # uses the animal choice to map to appropriate function pointer and create Animal object
        animals.append(mappings[animal_choice]())

    return animals  # list of Animal objects


def generate_animals_randomly(count):
    """Make a list of Animal objects with a random number of each Animal and randomly generated properties."""
    animals = []
    for _ in range(count):
        # chooses an animal at random from one of the map keys
        animal_choice = np.random.choice(list(mappings.keys()))
        # generates a list of 1 animal and takes the first element
        animals.append(generate_animals(animal_choice, 1)[0])

    return animals  # list of Animal objects


def identify_color(animal):
    """Identify the closest color from the Animal object's color list using Euclidean distance of RGB properties."""
    min_dist = None
    identified_color = None
    for color in animal.colors:
        color_rgb = color_rgbs[color]
        dist = ((animal.get_red - color_rgb[0]) ** 2) + (
            (animal.get_green - color_rgb[1]) ** 2) + ((animal.get_blue - color_rgb[2]) ** 2)
        if dist < min_dist or min_dist is None:
            min_dist = dist
            identified_color = color
    return identified_color


def unpack_animals(animals):
    """Make a dictionary mapping animal key to a list of animal attribute tuples."""
    return {
        # unwrap Animal object into a tuple of its properties, key is unique to Animal species
        animals[0].key: [(a.get_weight(), a.get_red(),
                          a.get_green(), a.get_blue(), identify_color(a)) for a in animals]
    }