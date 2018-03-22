using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    public GameObject ExplosionPrefab;
    public GameObject Keys;

    private float latestDirectionChangeTime;
    private float characterVelocity = 2f;
    private readonly float directionChangeTime = 1f;
    private Vector2 movementPerSecond;
    private Vector2 moveDirection;
    public double EnemyLife = 5f;
    public float power = 10;
    
    private Rigidbody2D mRigidBody2D;

    Animator myAnimator;
    bool enemyUp;
    bool enemyDown;
    bool enemyLeft;
    bool enemyRight;

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("????");
        if (col.gameObject.layer==LayerMask.NameToLayer("Bullet"))
        {
            Debug.Log("89");
            Destroy(col.gameObject);
            
            EnemyLife =EnemyLife-0.5f;

            if(EnemyLife<=0)
            {
                Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Instantiate(Keys, transform.position, Quaternion.identity);
            }
            
        }
        if(col.gameObject.layer==LayerMask.NameToLayer("Player"))
        {
            
            col.gameObject.GetComponent<Life>().DeductHealth(0.05f);
        }
    }

	// Use this for initialization
	void Start () {
        latestDirectionChangeTime = 0f;
        calculateNewMovememntVector();
        mRigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
        //if the changeTime was reached, calculate a new movement vector
        if(Time.time-latestDirectionChangeTime>directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calculateNewMovememntVector();
        }

        //enemy move
        // transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
        mRigidBody2D.AddForce(moveDirection, ForceMode2D.Impulse);
       //Debug.Log("Power: " + moveDirection);

        if(moveDirection.x>0)
        {
            enemyRight = true;
            enemyLeft = false;
        }
        else if(moveDirection.x<0)
        {
            enemyRight = false;
            enemyLeft = true;
        }

        if (moveDirection.y > 0)
        {
            enemyUp = true;
            enemyDown = false;
        }
        else if (moveDirection.y < 0)
        {
            enemyUp = false;
            enemyDown = true;

        }

        myAnimator.SetBool("isMovingUp", enemyUp);
        myAnimator.SetBool("isMovingDown", enemyDown);
        myAnimator.SetBool("isMovingLeft", enemyLeft);
        myAnimator.SetBool("isMovingRight", enemyRight);
        
    }

    public void calculateNewMovememntVector()
    {
        
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        moveDirection = new Vector2( Random.Range(-1.0f, 1.0f) , Random.Range(-1.0f, 1.0f)) * power;
        movementPerSecond = moveDirection * characterVelocity;
        

    }
}
