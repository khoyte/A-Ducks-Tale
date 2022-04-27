using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

public GameObject player;    
private Vector3 offset;  
public float farLeft,farRight;
// Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        offset = new Vector3(offset.x,0,offset.z);
    }

// LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        transform.position = new Vector3(player.transform.position.x, 0.34f, 0f) + offset; // we just copy the X and Z values
          
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, farLeft, farRight),0.34f,0f);
    }
}
