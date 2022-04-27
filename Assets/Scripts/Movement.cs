using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public CapsuleCollider2D coll;
    [SerializeField] private LayerMask ground;
    public float jump,speed,k=0;
    Vector3 currentEulerAngles;
    Quaternion currentRotation;
    private Animator animator;
    public int i = 0,jumps = 0;
    public Pond pond;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Application was quitted.");
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

        if(!pond.begin)
        {
            speed=Input.GetAxisRaw("Horizontal");
            rb.velocity=new Vector2(speed*7f,rb.velocity.y);
            if(i == 0){
                if(rb.velocity.x == 0){
                    animator.Play("Idle");
                }
                if(rb.velocity.x != 0 && IsGrounded()){
                    animator.Play("Walk");
                }
            }
            else {
                i--;
            }
            
            if(Input.GetButtonDown("Jump") && IsGrounded())
            {
                i = 5;
                animator.Play("Jump");
                rb.velocity=new Vector2(rb.velocity.x,jump);
                jumps--;
            }
            if(k>0)
            {
                k-=Time.deltaTime;
            }  
        }
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
    }

    private bool IsGrounded()
    {
        if(k>0)
        {
            if(jumps>0)
            {
                return true;
            }
            if(Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground))
            {
                jumps=2;
            }
        }
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
    }

    
}