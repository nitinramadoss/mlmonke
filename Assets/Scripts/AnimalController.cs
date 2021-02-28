using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimalController
{
    public static Dictionary<string, ArrayList> animalMap = new Dictionary<string, ArrayList>();

    public class AnimalObj
    {
        public string weight;
        public string red;
        public string green;
        public string blue;
        public string colorName;

        public AnimalObj(string weight, string red, string green, string blue, string colorName)
        {
            this.weight = weight;
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.colorName = colorName;
        }
    }

}
