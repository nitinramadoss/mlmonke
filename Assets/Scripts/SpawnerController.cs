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
        }

        public void addSpawner(Transform s)
        {
            spawners[spawners.Length - 1] = s;   
        }

        public void addAnimal(GameObject s)
        {
            animals[animals.Length - 1] = s;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //InitializeBiomes();
        Debug.Log(allAnimals[0].name);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            RandomlySpawnAnimals();
        } 
    }

    void InitializeBiomes()
    {
        Biome jungle = new Biome("Jungle", 4);
        Biome swamp = new Biome("Swamp", 4);
        Biome beach = new Biome("Beach", 2);

        // Add spawners to each biome instance
        for (int i = 0; i < SPAWNER_COUNT; i++)
        {
         
        }
    }
    void RandomlySpawnAnimals()
    {
        int rand = Random.Range(0, allAnimals.Length);
        int randPoint = Random.Range(0, allSpawners.Length);

        Instantiate(allAnimals[rand], allSpawners[randPoint].position, transform.rotation);
    }
}
