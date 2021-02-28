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

            AnimalResponse content = (AnimalResponse)JsonUtility.FromJson<AnimalResponse>(result);

            Debug.Log(content.monkey);

        }
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
