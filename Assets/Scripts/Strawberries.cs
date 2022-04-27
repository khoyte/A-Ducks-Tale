using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberries : MonoBehaviour
{
    public Movement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Enter");
        if( col.CompareTag("Player"))
        { 
            player.k=5;
            player.jumps=2;
            Debug.Log("Strawberry");
        }
    }
}
