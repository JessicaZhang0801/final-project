using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medicine : MonoBehaviour {



    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer==LayerMask.NameToLayer("Player"))
        {
           
           col.GetComponent<Life>().AddHealth(0.1f);
            Destroy(gameObject);
        }
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
