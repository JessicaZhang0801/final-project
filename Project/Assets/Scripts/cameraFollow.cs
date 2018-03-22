using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public Transform mTarget;
    public Vector3 offset;
    float FollowSpeed = 3.5f;
    float stepOverThreshold = 0.05f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(mTarget.position.x + offset.x, mTarget.position.y + offset.y, mTarget.position.z + offset.z);
        /*
		if(mTarget!=null)
        {
            Vector3 targetPosition = new Vector3(mTarget.transform.position.x, transform.position.y, transform.position.z);
            Vector3 direction = targetPosition - transform.position;
            if(direction.magnitude>stepOverThreshold)
            {
                //If too far, translate at FollowSpeed
                transform.Translate(direction.normalized * FollowSpeed * Time.deltaTime);
            }
            else
            {
                //If close enough,just step over
                transform.position = targetPosition;
            }
        }
        if(mTarget.position.y>transform.position.y)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, mTarget.transform.position.y, transform.position.z);
            Vector3 direction = targetPosition - transform.position;
        }
        */
	}
}
