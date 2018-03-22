using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    bool movingHorizontal;
    bool movingUp;
    bool movingDown;
    //bool running;

   
    // AudioSource BGM;

    Vector2 verticalDirection = Vector2.zero;
    Vector2 direction = Vector2.right;

    public float walkSpeed = 3;
    //public float speedUp = 6;

    // References to other components (can be from other game objects!)
    Animator myAnimator;
    Rigidbody2D myRigidBody2D;
    SpriteRenderer mySpriteRenderer;
    AudioSource getKey;
    // Use this for initialization
    void Start () {
        //get reference
        myAnimator = GetComponent<Animator>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        AudioSource[] audioSource = GetComponents<AudioSource>();
        getKey = audioSource[3];
       // BGM = audioSource[0];
       // BGM.Play();
	}
	
	// Update is called once per frame
	void Update () {
        movementHorizontal();

        //verticalDirection = Vector2.zero;

        movementDown();
        movementUp();
        

        myAnimator.SetBool("isMovingHorizontal", movingHorizontal);
        myAnimator.SetBool("isMovingUp", movingUp);
        myAnimator.SetBool("isMovingDown", movingDown);
       // myAnimator.SetBool("isRunning", running);
        

    }

    //左右行走
    private void movementHorizontal()
    {
        //running = Input.GetButton("SpeedUp");
        movingHorizontal = Input.GetButton("Horizontal");
        float direction = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(direction, 0, 0) * walkSpeed * Time.deltaTime;
        /*
        //Speed Up
        if(running &&Input.GetButton("Horizontal"))
        {
            transform.position += new Vector3(direction, 0, 0) * speedUp * Time.deltaTime;
            
        }
        */
        FaceDirection(new Vector2(direction, 0));
    }
    //上下行走
    /*
    private void movementVertical()
    {
        running = Input.GetButton("SpeedUp");

        movingHorizontal = Input.GetButton("Vertical");
        float direction = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(0, direction, 0) * walkSpeed * Time.deltaTime;
        //Speed Up
        if (running && Input.GetButton("Vertical"))
        {
            transform.position += new Vector3(0, direction, 0) * speedUp * Time.deltaTime;

        }
        FaceDirection(new Vector2(0, direction));
    }
    */
    
    private void movementUp()
    {
        movingUp = Input.GetButton("Up");
        float direction1 = Input.GetAxisRaw("Up");
        transform.position += new Vector3(0, direction1, 0) * walkSpeed * Time.deltaTime;
        /*
        //Speed Up
        if (running && Input.GetButton("Up"))
        {
            transform.position += new Vector3(0, direction1, 0) * speedUp * Time.deltaTime;
        }
        
        if (direction1 != 0)
            verticalDirection = new Vector2(0, direction1);*/
    }
    
    private void movementDown()
    {
        movingDown = Input.GetButton("Down");
        float direction1 = Input.GetAxisRaw("Down");
        transform.position += new Vector3(0, direction1, 0) * walkSpeed * Time.deltaTime;
        /*
        //Speed Up
        if (running && Input.GetButton("Down"))
        {
            transform.position += new Vector3(0, direction1, 0) * speedUp * Time.deltaTime;
        }
        
        if (direction1 != 0)
            verticalDirection = new Vector2(0, direction1);*/
    }
    
    //面向方向
    private void FaceDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)
            return;

        if (direction.x == -1)
            mySpriteRenderer.flipX = true;
        else  
            mySpriteRenderer.flipX = false;

        this.direction = direction;
        //This is only for HORIZONTAL
        //Quaternion rotation3D = direction == Vector2.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back);
        //transform.rotation = rotation3D;
    }

    

    public Vector2 GetFacingDirection()
    {
        Debug.Log("Direction: " + new Vector2(direction.x, verticalDirection.y));
        return new Vector2(direction.x,verticalDirection.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.layer == LayerMask.NameToLayer("Key"))
        {
            getKey.Play();
            key.keyNumber += 1;
            Destroy(col.gameObject);
        }
    }

    }
