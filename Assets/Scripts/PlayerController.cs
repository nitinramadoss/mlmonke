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
        position.x = Input.GetAxisRaw("Horizontal");
        position.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (position != body.position)
        {
            body.MovePosition(body.position + position * speed * Time.fixedDeltaTime);
        }
    }
}
