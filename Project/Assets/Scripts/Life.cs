using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Life : MonoBehaviour {

    public float maxHealth = 1;
    public GameObject DeathParticleEmitter;
    public Image lifeBar;
    
    AudioSource TakeDamage;
    AudioSource Recover;
    //AudioSource Death;
    Vector2 FacingDirection;
    float DamagePushForce = 2.5f;
    Rigidbody2D mRigidBody2D;


	// Use this for initialization
	void Start ()
    {
        AudioSource[] audiosource = GetComponents<AudioSource>();
        TakeDamage = audiosource[1];
        Recover = audiosource[2];
        //Death = audiosource[3];
        mRigidBody2D = GetComponent<Rigidbody2D>();
        FacingDirection = Vector2.right;
	}

    public void AddHealth(float x)
    {
        maxHealth += x;
        lifeBar.fillAmount = maxHealth;
        Recover.Play();
    }
    public void DeductHealth(float x)
    {
        maxHealth -=x;
        lifeBar.fillAmount = maxHealth;
        TakeDamage.Play();

        Vector2 forceDirection = new Vector2(-FacingDirection.x, 1.0f) * DamagePushForce;
        mRigidBody2D.velocity = Vector2.zero;
        mRigidBody2D.AddForce(forceDirection, ForceMode2D.Impulse);

        if(maxHealth<=0)
        {
           // Death.Play();
            Die();
        }


    }
    public void Die()
    {
        Debug.Log("die");
        
        Instantiate(DeathParticleEmitter, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //SceneManager.LoadScene("gameOver");
    }
    
	// Update is called once per frame
	void Update () {
        
            if (countDown.CountDown == 0)
            {
                Die();
            }
        

    }
}
