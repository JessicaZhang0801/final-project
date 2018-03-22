using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExit : MonoBehaviour {

    public Door myDoor;
    public Transform entrance;
    public GameObject keyEnemy;
    AudioSource doorClose;

    void Start()
    {
        AudioSource[] audiosource = GetComponents<AudioSource>();
        doorClose = audiosource[0];
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if ( myDoor.entered == false)//player的entered变成true出不去，所以需要出exit方框变成false
            {
                if (keyEnemy == null)
                {
                    myDoor.exited = true;//entered，exited都是false，会出现反复横跳的效果
                    doorClose.Play();   
                    myDoor.Teleport(col.gameObject, entrance);
                    
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myDoor.entered = false;

        }
    }
}
