using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class DataRequester
{
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

        SendData("https://351ac1a19a3a.ngrok.io/results");
    }

    public class PostBody
    {
        public Data data;
        public string model; 

        public class Data
        {
            public string[] cobra; // 4
            public string[] crocodile; // 3
            public string[] duck; // 7
            public string[] frog; // 5
            public string[] hippo; // 2
            public string[] lion; // 1
            public string[] monkey; // 0 
            public string[] parrot; // 6 
            public string[] seagull; // 8
        }
    }

    public static IEnumerator SendData(string url)
    {
        PostBody body = loadDataIntoBody();

        string jsonString = JsonUtility.ToJson(body, true);

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

    public static PostBody loadDataIntoBody()
    {
        PostBody body = new PostBody();
        body.model = "0";

        PostBody.Data bodyData = new PostBody.Data();

        var animalMap = AnimalController.animalMap;

        bodyData.cobra = new string[animalMap["Cobra"].Count * 4];
        bodyData.crocodile = new string[animalMap["Crocodile"].Count * 4];
        bodyData.duck = new string[animalMap["Duck"].Count * 4];
        bodyData.frog = new string[animalMap["Frog"].Count * 4];
        bodyData.hippo = new string[animalMap["Hippo"].Count * 4];
        bodyData.lion = new string[animalMap["Lion"].Count * 4];
        bodyData.monkey = new string[animalMap["Monkey"].Count * 4];
        bodyData.parrot = new string[animalMap["Parrot"].Count * 4];
        bodyData.seagull = new string[animalMap["Seagull"].Count * 4];

        int index = 0;
        for ( int i = 0; i < animalMap["Cobra"].Count; i++)
        {
            AnimalController.AnimalObj obj = (AnimalController.AnimalObj) animalMap["Cobra"][i];
            bodyData.cobra[index++] = obj.weight;
            bodyData.cobra[index++] = obj.red;
            bodyData.cobra[index++] = obj.green;
            bodyData.cobra[index++] = obj.blue;
        }

        index = 0;
        for (int i = 0; i < animalMap["Crocodile"].Count; i++)
        {
            AnimalController.AnimalObj obj = (AnimalController.AnimalObj)animalMap["Crocodile"][i];
            bodyData.crocodile[index++] = obj.weight;
            bodyData.crocodile[index++] = obj.red;
            bodyData.crocodile[index++] = obj.green;
            bodyData.crocodile[index++] = obj.blue;
        }

        index = 0;
        for (int i = 0; i < animalMap["Duck"].Count; i++)
        {
            AnimalController.AnimalObj obj = (AnimalController.AnimalObj)animalMap["Duck"][i];
            bodyData.duck[index++] = obj.weight;
            bodyData.duck[index++] = obj.red;
            bodyData.duck[index++] = obj.green;
            bodyData.duck[index++] = obj.blue;
        }

        index = 0;
        for (int i = 0; i < animalMap["Frog"].Count; i++)
        {
            AnimalController.AnimalObj obj = (AnimalController.AnimalObj)animalMap["Frog"][i];
            bodyData.frog[index++] = obj.weight;
            bodyData.frog[index++] = obj.red;
            bodyData.frog[index++] = obj.green;
            bodyData.frog[index++] = obj.blue;
        }

        index = 0;
        for (int i = 0; i < animalMap["Hippo"].Count; i++)
        {
            AnimalController.AnimalObj obj = (AnimalController.AnimalObj)animalMap["Hippo"][i];
            bodyData.hippo[index++] = obj.weight;
            bodyData.hippo[index++] = obj.red;
            bodyData.hippo[index++] = obj.green;
            bodyData.hippo[index++] = obj.blue;
        }

        index = 0;
        for (int i = 0; i < animalMap["Lion"].Count; i++)
        {
            AnimalController.AnimalObj obj = (AnimalController.AnimalObj)animalMap["Lion"][i];
            bodyData.lion[index++] = obj.weight;
            bodyData.lion[index++] = obj.red;
            bodyData.lion[index++] = obj.green;
            bodyData.lion[index++] = obj.blue;
        }

        index = 0;
        for (int i = 0; i < animalMap["Monkey"].Count; i++)
        {
            AnimalController.AnimalObj obj = (AnimalController.AnimalObj)animalMap["Monkey"][i];
            bodyData.monkey[index++] = obj.weight;
            bodyData.monkey[index++] = obj.red;
            bodyData.monkey[index++] = obj.green;
            bodyData.monkey[index++] = obj.blue;
        }

        index = 0;
        for (int i = 0; i < animalMap["Parrot"].Count; i++)
        {
            AnimalController.AnimalObj obj = (AnimalController.AnimalObj)animalMap["Parrot"][i];
            bodyData.parrot[index++] = obj.weight;
            bodyData.parrot[index++] = obj.red;
            bodyData.parrot[index++] = obj.green;
            bodyData.parrot[index++] = obj.blue;
        }

        index = 0;
        for (int i = 0; i < animalMap["Seagull"].Count; i++)
        {
            AnimalController.AnimalObj obj = (AnimalController.AnimalObj)animalMap["Seagull"][i];
            bodyData.seagull[index++] = obj.weight;
            bodyData.seagull[index++] = obj.red;
            bodyData.seagull[index++] = obj.green;
            bodyData.seagull[index++] = obj.blue;
        }


        body.data = bodyData;

        return body;
    }

    //StartCoroutine(DataRequester.SendData("https://351ac1a19a3a.ngrok.io/results"));
}
