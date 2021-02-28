# ML MonkeMon

Gamifying Machine Learning education to be accessible to all knowledge levels.

## Inspiration
Between the cumbersome notation and upper-level mathematics involved in the theory of ML, it can be quite difficult for interested beginners to get started without being bogged down and discouraged. Though it is true that Machine Learning is a nuanced field and the theory behind it is crucial to push the frontiers of AI, that is no reason to exclude youth with little experience from experiencing the magic of ML and understanding what it means at its core. We built this game to strip away the technical jargon of ML and provide tools for kids to interact with it on an abstract level while still learning some of its key concepts. 

## What it does
ML MonkeMon is a 2D top-down game that incorporates elements of Machine Learning into easy-to-understand mechanics. The player is a monkey (_Monke_) that has been sent by his professor on a study abroad trip across the jungle to collect data about the other animal inhabitants. In this first level, the monkey's goal is to develop an ML model to determine whether any given jungle animal is a mammal, reptilian/amphibian, or bird based solely on its weight and color (RGB values). It does so by traveling around the jungle map through the various biomes of forest, swamp, and beach and interacting with the randomly spawned animals (who contain information from their unique species distribution). For example, if the monkey (_Monke_) travels to the swamp, he may encounter some crocodiles and be able to collect their weights and colors, which reflect the weight and color distributions of crocodiles in real life. As the monkey (_Monke_) meets new animals, his MonkeDex, which he can open and close at any point via an in-game button, is updated. The MonkeDex contains information about the average weight and possible colors for each species that he has encountered thus far, based on his current data. Once the player decides that they have collected enough data, they can click a button to open the Train Model screen, where they can choose between training a KNN Classifier or a Random Forest Classifier on their collected data. This returns a plot of their model's accuracy graphed against a varied parameter (number of nearest neighbors or number of trees depending on the algorithm chosen). Throughout the game, a 5-minute timer ticks down, and if it expires, the game ends, so the player must be wary of balancing the variety in the data collected, the amount of data collected, and the complexity of the model generated.   

## How we built it
The backend was written in Python using common libraries such as NumPy for N-dimensional vectors & matrices, Sci-Kit Learn for classifiers, fitting, & accuracy computation, and MatPlotLib for generating a figure at the end. All the animal data was encapsulated into classes for each species and inheritance was utilized to wrap them together and under superclasses for Mammal, Reptile/Amphibian, and Bird. We researched distributions of the data for real animal species and utilized NumPy to generate the object properties that we passed to randomized Animal constructors. All of this code was deployed on a Flask endpoint for the game to make GET and POST HTTP requests in order to generate animal data and get results based on training data.

## Challenges we ran into

## Accomplishments that we're proud of
This entire project was in a totally new domain for our whole team, so we're really proud that we were able to make a fully-fledged game that can be played from start to finish. At many points during the project, it was difficult to see it panning out, but we kept our heads in the game [and our eyes on StackOverflow] and we ultimately figured out how to overcome all our difficulties. Interfacing between the Unity C# scripts and the Flask endpoint was one of the most challenging parts and our debugging session for that was quite stressful, but it was all the more satisfying when we finally figured out the problems and the process and were finally able to randomly generate all the animals onto the map with one request to the Flask application.

## What we learned
This project was a huge learning experience for us. For one thing, only one member of the team (Arnav) was familiar with machine learning, and though he had studied some of the mathematics and theory behind ML, this was his first time working with ML libraries in a hackathon. For that reason, he spent quite a while at the beginning of the hackathon reading documentation to understand exactly how the library functions and interacted and planning how to set up the project flow. Though it was time-consuming and resulted in a late start of actually programming the backend, it made the backend code very clean and easy, and everything was able to be nicely modularized. Despite having worked with Python some in the past, there were tons of things that Arnav learned about Python as well from keyword arguments to function pointers.

For the remaining 3 members of the team, developing the game itself was no mean feat. This was the first time all 3 members were doing game development, so Unity and C# alike were foreign to everyone. Furthermore, 1 of the 3 members had just done his first hackathon one week ago, so he was very new to this sort of programming project. There were tons of things to learn about Unity and C# from the basics of game development all the way to managing complex data structures and parsing JSON responses from C# HTTP requests, so we're really proud that we were able to develop this game to interface smoothly with the backend and operate fairly well in gameplay.  

## What's next for ML MonkeMon
We plan to add more levels that gradually introduce more complicated decisions for the player to learn further aspects of ML. For example, we plan to add levels that require the player to be involved in feature selection, more diverse algorithms (including regression models), more sophisticated algorithms such as neural networks, and parameter optimization. We wanted to start out at a level that was comprehensible to kids of all skill levels before slowly ramping up the difficulty of the gameplay. To complete each level, the user would have to produce a model that meets a certain accuracy threshold for that level, and as the user has to balance more and more factors, it would become more difficult to meet this threshold given the time constraints (which effectively represent the computational resources available for data collection and analysis). 