using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        UpdatePosition();   

    }

    void FixedUpdate()
    {
        if (position != body.position)
        {
            body.MovePosition(body.position + position * speed * Time.fixedDeltaTime);
        }
    }

    void UpdatePosition()
    {
        position.x = Input.GetAxisRaw("Horizontal");
        position.y = Input.GetAxisRaw("Vertical");

        if (position.x == 1)
        {
            this.GetComponent<Animator>().Play("walkHRight");
        } else if (position.x == -1)
        {
            this.GetComponent<Animator>().Play("walkHLeft");
        }

        if (position.y == 1)
        {
            this.GetComponent<Animator>().Play("walkVUp");
        }
        else if (position.y == -1)
        {
            this.GetComponent<Animator>().Play("walkVDown");
        }
       
    } 
}
