using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    Biome[] biomes; // jungle, swamp, and beach
   
    public Transform[] allSpawners;
    public GameObject[] allAnimals;

    private ArrayList randomlySpawnedAnimals;

    private const int SPAWNER_COUNT = 10;

    // spawned animation state
    private bool move;

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
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomlySpawnedAnimals != null && move)
        {
            StartCoroutine(AnimateNPCS());
        }
    }

    void InitializeBiomes()
    {
        biomes = new Biome[3];

        biomes[0] = new Biome("Jungle", 4);
        biomes[1] = new Biome("Swamp", 4);
        biomes[2] = new Biome("Beach", 2);

        // Add spawners to each biome instance
        for (int i = 0; i < SPAWNER_COUNT; i++)
        {
            if (i < 4)
            {
                biomes[0].addSpawner(allSpawners[i]);
            } else if (i < 8)
            {
                biomes[1].addSpawner(allSpawners[i]);
            } else
            {
                biomes[2].addSpawner(allSpawners[i]);
            }
        }
      
        // Add animals to each biome instance
        string[] jungleAnimalNames = {"Monkey", "Lion", "Parrot", "Frog"};
        string[] swampAnimalNames = { "Duck", "Hippo", "Crocodile", "Cobra" };
        string[] beachAnimalNames = { "Duck", "Seagull"};

        foreach (GameObject animal in allAnimals)
        {
            if (Array.IndexOf(jungleAnimalNames, animal.name) != -1)
            {
                biomes[0].addAnimal(animal);
            }

            if (Array.IndexOf(swampAnimalNames, animal.name) != -1)
            {
                biomes[1].addAnimal(animal);
            }

            if (Array.IndexOf(beachAnimalNames, animal.name) != -1)
            {
                biomes[2].addAnimal(animal);
            }
        }

        

        RandomlySpawnAnimals();
    }
    void RandomlySpawnAnimals()
    {
        randomlySpawnedAnimals = new ArrayList();

        const int MAX_ANIMALS_PER_SPAWNER = 7;
        const int MIN_ANIMALS_PER_SPAWNER = 3;

        foreach (Biome biome in biomes) // 3 biomes
        {
            for (int i = 0; i < biome.spawners.Count; i++) // 10 spawners total
            {
                int numAnimals = UnityEngine.Random.Range(MIN_ANIMALS_PER_SPAWNER, MAX_ANIMALS_PER_SPAWNER);

                for (int iter = 0; iter < numAnimals; iter++) {
                    Vector3 randPoint = GetRandomSpawnPoint((Transform)biome.spawners[i]);

                    GameObject animalClone = Instantiate((GameObject)biome.animals[i], randPoint, transform.rotation);
                    randomlySpawnedAnimals.Add(animalClone);
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

    IEnumerator AnimateNPCS()
    {
        move = false;

        AnimateNPCHelper();

        yield return new WaitForSeconds(1f);

        AnimateNPCHelper();

        yield return new WaitForSeconds(1f);

        move = true;
    }

    void AnimateNPCHelper()
    {
        const int MAX_WALK_DISTANCE = 5;
        const int MIN_WALK_DISTANCE = -5;
        const float speed = 4f;

        foreach (GameObject animal in randomlySpawnedAnimals)
        {
            animal.SetActive(true);


            Rigidbody2D rb = animal.GetComponent<Rigidbody2D>();

            int randX = UnityEngine.Random.Range(MIN_WALK_DISTANCE, MAX_WALK_DISTANCE);
            int randY = UnityEngine.Random.Range(MIN_WALK_DISTANCE, MAX_WALK_DISTANCE);
            Vector2 position = new Vector2(randX, randY);

            if (randX > 0)
            {
                animal.GetComponent<Animator>().Play("walkHRight");
            }
            else
            {
                animal.GetComponent<Animator>().Play("walkHLeft");
            }

            animal.GetComponent<Rigidbody2D>().MovePosition(rb.position + position * speed * Time.fixedDeltaTime);
        }
    }
}
