using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEntrance : MonoBehaviour {

    public Door myDoor;
    public Transform exit;
    AudioSource openDoor;

    void Start()
    {
        AudioSource[] audiosource = GetComponents<AudioSource>();
        openDoor = audiosource[0];
    }
    

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (key.keyNumber >= myDoor.requiredKey && myDoor.exited == false)
            {
                myDoor.entered = true;  //Don't teleport back out as soon as you go in.
                openDoor.Play();
                //SceneManager.LoadScene("maze1");
                myDoor.Teleport(col.gameObject, exit);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myDoor.exited = false;
            
        }
    }

}
