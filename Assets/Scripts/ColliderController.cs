using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            MetAnimal();

            GameObject.Destroy(this.gameObject);
        } else
        {
            //base.OnTriggerEnter2D(other);
        }
    }

    public void MetAnimal()
    {
      string metAnimalName = this.gameObject.name.Replace("(Clone)", "");

       foreach (AnimalController.AnimalObj animalObj in AnimalController.animalMap[metAnimalName])
       {
            if (!animalObj.met)
            {
                animalObj.met = true;
                Debug.Log(animalObj.weight);
            }   
       }
    }
}
