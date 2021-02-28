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
        public ArrayList spawners; // Transforms
        public ArrayList animals; // Game objects
        public int size;

        public Biome(string name, int numSpawners)
        {
            this.name = name;
            this.numSpawners = numSpawners;

            spawners = new ArrayList();
            animals = new ArrayList();
        }

        public void addSpawner(Transform s)
        {
            spawners.Add(s);
        }

        public void addAnimal(GameObject a)
        {
            animals.Add(a);
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
        Debug.Log(jungle.spawners[0]);
        // Add animals to each biome instance
        string[] jungleAnimalNames = {"Monkey", "Lion", "Parrot", "Frog"};
        string[] swampAnimalNames = { "Duck", "Hippo", "Crocodile", "Cobra" };
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
        const int MAX_ANIMALS_PER_SPAWNER = 7;
        const int MIN_ANIMALS_PER_SPAWNER = 3;

        foreach (Biome biome in biomes) // 3 biomes
        {
            for (int i = 0; i < biome.spawners.Count; i++) // 10 spawners total
            {
                int numAnimals = UnityEngine.Random.Range(MIN_ANIMALS_PER_SPAWNER, MAX_ANIMALS_PER_SPAWNER);

                for (int iter = 0; iter < numAnimals; iter++) {
                    Vector3 randPoint = GetRandomSpawnPoint((Transform)biome.spawners[i]);

                    Instantiate((GameObject)biome.animals[i], randPoint, transform.rotation);
                }
            }
        }
    }

    Vector3 GetRandomSpawnPoint(Transform spawner)
    {
        const int OFFSET = 5;
        int randX = UnityEngine.Random.Range((int)spawner.position.x-OFFSET, (int)spawner.position.x + OFFSET);
        int randY = UnityEngine.Random.Range((int)spawner.position.y - OFFSET, (int)spawner.position.y + OFFSET);

        Vector3 spawnPoint = new Vector3(randX, randY, spawner.position.z);

        return spawnPoint;
    }
}
