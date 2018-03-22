using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    int Speed = 20;
    public Rigidbody2D bullet;
    public Transform FPoint;
    AudioSource BulletSound;
    Player myPlayer;
	// Use this for initialization
	void Start () {
        AudioSource[] audiosource = GetComponents<AudioSource>();
        BulletSound = audiosource[0];
        BulletSound = GetComponent<AudioSource>();
        myPlayer = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))//SHOOT
        {
            Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = cursorInWorldPos - (Vector2)transform.position;
            direction.Normalize();
            Rigidbody2D clone;
            clone = Instantiate(bullet, FPoint.position, FPoint.rotation);
            clone.velocity = transform.TransformDirection(direction * 10);
            BulletSound.Play();

        }
	}
    
}
