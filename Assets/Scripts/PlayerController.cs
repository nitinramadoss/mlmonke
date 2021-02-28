using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    Vector2 position;
    private float speed = 5f;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMCPosition();   

    }

    void FixedUpdate()
    {
        if (position != body.position)
        {
            body.MovePosition(body.position + position * speed * Time.fixedDeltaTime);
        }
    }

    void UpdateMCPosition()
    {
        position.x = Input.GetAxisRaw("Horizontal");
        position.y = Input.GetAxisRaw("Vertical");

        if (position.x == 0 && position.y == 0)
        {
            this.GetComponent<Animator>().Play("idle");
        } else {
            if (position.x == 1)
            {
                this.GetComponent<Animator>().Play("walkHRight");
            }
            else if (position.x == -1)
            {
                this.GetComponent<Animator>().Play("walkHLeft");
            }
            else if (position.y == 1)
            {
                this.GetComponent<Animator>().Play("walkVUp");
            }
            else if (position.y == -1)
            {
                this.GetComponent<Animator>().Play("walkVDown");
            }
        }   

        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(RequestData("https://f42059067a63.ngrok.io/"));
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(SendData("https://cbd2406ef0a2.ngrok.io/results"));
        }


    } 

    IEnumerator RequestData(string url)
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
            Debug.Log(request.downloadHandler.text);
        }
    }

    IEnumerator SendData(string url)
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
