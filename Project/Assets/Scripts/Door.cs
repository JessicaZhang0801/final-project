using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool entered = false;
    public bool exited = false;
    public int requiredKey = 0;


    public void Teleport(GameObject target, Transform location)
    {
        target.transform.position = location.position;
    }

    void Start()
    {

    }
    void Update()
    {
        
    }

}
