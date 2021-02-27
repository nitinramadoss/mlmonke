using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] animals;

    public class Biome
    {
        public string name;

        public Biome(string name)
        {
            this.name = name;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            RandomlySpawnAnimals();
        } 
    }

    void RandomlySpawnAnimals()
    {
        int rand = Random.Range(0, animals.Length);
        int randPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(animals[0], spawnPoints[randPoint].position, transform.rotation);
    }
}
