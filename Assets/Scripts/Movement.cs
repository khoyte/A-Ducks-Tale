using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jump,speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed=Input.GetAxisRaw("Horizontal");
        rb.velocity=new Vector2(speed*7f,rb.velocity.y);
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity=new Vector2(rb.velocity.x,jump);
        }
    }
}
