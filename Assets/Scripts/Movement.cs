using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public CapsuleCollider2D coll;
    [SerializeField] private LayerMask ground;
    public float jump,speed;
    Vector3 currentEulerAngles;
    Quaternion currentRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed=Input.GetAxisRaw("Horizontal");
        rb.velocity=new Vector2(speed*7f,rb.velocity.y);
        if(rb.velocity.x<0)
        {
            currentEulerAngles = new Vector3(0, 180, 0);
            currentRotation.eulerAngles = currentEulerAngles;
            transform.rotation = currentRotation;
        }
        else{
            currentEulerAngles = new Vector3(0, 0, 0);
            currentRotation.eulerAngles = currentEulerAngles;
            transform.rotation = currentRotation;
        }
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity=new Vector2(rb.velocity.x,jump);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
    }
}