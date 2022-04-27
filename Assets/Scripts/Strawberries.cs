using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberries : MonoBehaviour
{
    public Movement player;

    //OnCollisionEnter

    private void OnTriggerEnter2D(Collider2D col)
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
