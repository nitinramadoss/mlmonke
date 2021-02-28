using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public Transform[] allSpawners;
    public GameObject[] allAnimals;
    private const int SPAWNER_COUNT = 10;

    class Biome
    {
        public string name;
        public int numSpawners;
        public Transform[] spawners;
        public GameObject[] animals;

        public Biome(string name, int numSpawners)
        {
            this.name = name;
            this.numSpawners = numSpawners;

            spawners = new Transform[numSpawners];
            animals = new GameObject[numSpawners];
        }

        public void addSpawner(Transform s)
        {
            spawners[spawners.Length - 1] = s;   
        }

        public void addAnimal(GameObject a)
        {
            animals[animals.Length - 1] = a;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InitializeBiomes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitializeBiomes()
    {
        Biome jungle = new Biome("Jungle", 4);
        Biome swamp = new Biome("Swamp", 4);
        Biome beach = new Biome("Beach", 2);

        // Add spawners to each biome instance
        for (int i = 0; i < SPAWNER_COUNT; i++)
        {
            if (i < 4)
            {
                jungle.addSpawner(allSpawners[i]);
            } else if (i < 8)
            {
                swamp.addSpawner(allSpawners[i]);
            } else
            {
                beach.addSpawner(allSpawners[i]);
            }
        }

        // Add animals to each biome instance
        string[] jungleAnimalNames = {"Monkey", "Lion", "Parrot", "Frog"};
        string[] swampAnimalNames = { "Duck", "Hippo", "Crocodile", "Snake" };
        string[] beachAnimalNames = { "Duck", "Seagull"};

        foreach (GameObject animal in allAnimals)
        {
            if (Array.IndexOf(jungleAnimalNames, animal.name) != -1)
            {
                jungle.addAnimal(animal);
            }

            if (Array.IndexOf(swampAnimalNames, animal.name) != -1)
            {
                swamp.addAnimal(animal);
            }

            if (Array.IndexOf(beachAnimalNames, animal.name) != -1)
            {
                beach.addAnimal(animal);
            }
        }

        Biome[] biomes = {jungle, swamp, beach};

        RandomlySpawnAnimals(biomes);
    }
    void RandomlySpawnAnimals(Biome[] biomes)
    {

        foreach (Biome biome in biomes)
        {

            int rand = UnityEngine.Random.Range(0, allAnimals.Length);
            int randPoint = UnityEngine.Random.Range(0, allSpawners.Length);

            Instantiate(allAnimals[rand], allSpawners[randPoint].position, transform.rotation);
        }
    }

    void GetRandomPosition(Transform spawner)
    {
        const int OFFSET = 5;

    }
}
