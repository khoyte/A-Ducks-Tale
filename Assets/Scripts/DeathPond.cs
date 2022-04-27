using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPond : MonoBehaviour
{
    private Vector3 end1,end2,end3, start;
    private float time=0;
    public bool begin= false;
    public GameObject player;
    public BoxCollider2D box;
    private int bobs=0;

    void Update()
    {
        if(begin)
        {
            time+=Time.deltaTime;
            float percent=time/1f;
            if(bobs==0||bobs==2||bobs==4){
                player.transform.position=Vector3.Lerp(start,end1,percent);
            }
            else if(bobs==1||bobs==3||bobs==5){
                player.transform.position=Vector3.Lerp(end1,end2,percent);
            }
            if(bobs==6)
            {
                player.transform.position=Vector3.Lerp(end2,end3,percent);
            }
            if(bobs==2)
            {
                //input new state where he is sad.
            }
            if(percent>=1)
            {
                bobs++;
                time=0;
            }
            
            if(bobs==7)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if( col.CompareTag("Player"))
        {
            start=player.transform.position;
            
            begin=true;
            box.enabled=!box.enabled;
            end1=new Vector3(start.x,start.y-0.3f,start.z);
            end2=new Vector3(start.x,start.y,start.z);
            end3=new Vector3(start.x,start.y-4f,start.z);
        }
    }
}
