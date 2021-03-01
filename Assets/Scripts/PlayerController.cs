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
        StartCoroutine(DataRequester.SendData("https://351ac1a19a3a.ngrok.io/results"));
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

    } 
}
