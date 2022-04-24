using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x=Input.GetAxisRaw("Horizontal");
        rb.velocity=new Vector2(x*7f,rb.velocity.y);
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity=new Vector2(rb.velocity.x,14);
        }
    }
}
