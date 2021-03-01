using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderController : MonoBehaviour
{
    private Text dialogue;

    // Start is called before the first frame update
    public void Start()
    {
        dialogue = GameObject.Find("DialogueText").GetComponent<Text>();
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

            UpdateDialogue(animalObj.weight, animalObj.colorName);
       }
    }

    public void UpdateDialogue(string weight, string colorName)
    {
        dialogue.text = "Collecting data... Weight: " +  weight + " lbs " + "Color: " + colorName;

        StartCoroutine(DataRequester.SendData("http://d08180a0d716.ngrok.io/results"));
    }
}
