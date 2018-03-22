using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealBullet : MonoBehaviour {

    public GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {

            Destroy(col.gameObject);
        }
    }
}
