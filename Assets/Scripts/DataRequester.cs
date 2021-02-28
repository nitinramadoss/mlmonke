using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class DataRequester
{
    // if (Input.GetKeyDown(KeyCode.G))
    //    {
    //        StartCoroutine(RequestData("https://9b098af2afe2.ngrok.io/generate"));
    //    }

    //if (Input.GetKeyDown(KeyCode.H))
    //{
    //    StartCoroutine(SendData("https://cbd2406ef0a2.ngrok.io/results"));
    //}
    public static IEnumerator RequestData(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            // Show results as text
            string result = request.downloadHandler.text;
            Debug.Log(result);

            AnimalResponse animalResponse = (AnimalResponse)JsonUtility.FromJson<AnimalResponse>(result);


            loadAnimals(animalResponse);
        }
    }

    private static void loadAnimals(AnimalResponse animalResponse)
    {
        const int NUM_ELEMENTS_PER_ANIMAL = 5;

        AnimalController.animalMap.Add("Cobra", new ArrayList());
        AnimalController.animalMap.Add("Crocodile", new ArrayList());
        AnimalController.animalMap.Add("Duck", new ArrayList());
        AnimalController.animalMap.Add("Frog", new ArrayList());
        AnimalController.animalMap.Add("Hippo", new ArrayList());
        AnimalController.animalMap.Add("Lion", new ArrayList());
        AnimalController.animalMap.Add("Monkey", new ArrayList());
        AnimalController.animalMap.Add("Parrot", new ArrayList());
        AnimalController.animalMap.Add("Seagull", new ArrayList());

        for (int i = 0; i < animalResponse.cobra.Length; i += NUM_ELEMENTS_PER_ANIMAL)
        {
            AnimalController.animalMap["Cobra"].Add(new AnimalController.AnimalObj(animalResponse.cobra[i], animalResponse.cobra[i+1], 
                animalResponse.cobra[i+2], animalResponse.cobra[i+3], animalResponse.cobra[i+4]));        
        }

        for (int i = 0; i < animalResponse.crocodile.Length; i += NUM_ELEMENTS_PER_ANIMAL)
        {
            AnimalController.animalMap["Crocodile"].Add(new AnimalController.AnimalObj(animalResponse.crocodile[i], animalResponse.crocodile[i + 1],
                animalResponse.crocodile[i + 2], animalResponse.crocodile[i + 3], animalResponse.crocodile[i + 4]));
        }

        for (int i = 0; i < animalResponse.duck.Length; i += NUM_ELEMENTS_PER_ANIMAL)
        {
            AnimalController.animalMap["Duck"].Add(new AnimalController.AnimalObj(animalResponse.duck[i], animalResponse.duck[i + 1],
                animalResponse.duck[i + 2], animalResponse.duck[i + 3], animalResponse.duck[i + 4]));
        }

        for (int i = 0; i < animalResponse.frog.Length; i += NUM_ELEMENTS_PER_ANIMAL)
        {
            AnimalController.animalMap["Frog"].Add(new AnimalController.AnimalObj(animalResponse.frog[i], animalResponse.frog[i + 1],
                animalResponse.frog[i + 2], animalResponse.frog[i + 3], animalResponse.frog[i + 4]));
        }

        for (int i = 0; i < animalResponse.hippo.Length; i += NUM_ELEMENTS_PER_ANIMAL)
        {
            AnimalController.animalMap["Hippo"].Add(new AnimalController.AnimalObj(animalResponse.hippo[i], animalResponse.hippo[i + 1],
                animalResponse.hippo[i + 2], animalResponse.hippo[i + 3], animalResponse.hippo[i + 4]));
        }

        for (int i = 0; i < animalResponse.lion.Length; i += NUM_ELEMENTS_PER_ANIMAL)
        {
            AnimalController.animalMap["Lion"].Add(new AnimalController.AnimalObj(animalResponse.lion[i], animalResponse.lion[i + 1],
                animalResponse.lion[i + 2], animalResponse.lion[i + 3], animalResponse.lion[i + 4]));
        }

        for (int i = 0; i < animalResponse.monkey.Length; i += NUM_ELEMENTS_PER_ANIMAL)
        {
            AnimalController.animalMap["Monkey"].Add(new AnimalController.AnimalObj(animalResponse.monkey[i], animalResponse.monkey[i + 1],
                animalResponse.monkey[i + 2], animalResponse.monkey[i + 3], animalResponse.monkey[i + 4]));
        }

        for (int i = 0; i < animalResponse.parrot.Length; i += NUM_ELEMENTS_PER_ANIMAL)
        {
            AnimalController.animalMap["Parrot"].Add(new AnimalController.AnimalObj(animalResponse.parrot[i], animalResponse.parrot[i + 1],
                animalResponse.parrot[i + 2], animalResponse.parrot[i + 3], animalResponse.parrot[i + 4]));
        }

        for (int i = 0; i < animalResponse.seagull.Length; i += NUM_ELEMENTS_PER_ANIMAL)
        {
            AnimalController.animalMap["Seagull"].Add(new AnimalController.AnimalObj(animalResponse.seagull[i], animalResponse.seagull[i + 1],
                animalResponse.seagull[i + 2], animalResponse.seagull[i + 3], animalResponse.seagull[i + 4]));
        }

        //AnimalController.AnimalObj obj = (AnimalController.AnimalObj) AnimalController.animalMap["Monkey"][0];
    }

    public static IEnumerator SendData(string url)
    {
        string b = "";
        string jsonString = JsonUtility.ToJson(b, true);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.SetRequestHeader("Content-Type", "application/json");

        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");


        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            // Show results as text
            Debug.Log(request.downloadHandler.text);
        }
    }

}
