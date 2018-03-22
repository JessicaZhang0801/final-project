using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMonster : MonoBehaviour {
    public GameObject ExplosionPrefab;
    public GameObject Keys;

    public Transform mTarget;
    public float mFollowSpeed;
    public float mFollowRange;

    float mArriveThreshold = 0.05f;
    AudioSource explosion;
    public double RedMonsterLife = 3f;
    // Use this for initialization
    void Start () {
        AudioSource[] audiosource = GetComponents<AudioSource>();
        explosion = audiosource[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (mTarget != null)
        {
            // TODO: Make the enemy follow the target "mTarget"
            //       only if the target is close enough (distance smaller than "mFollowRange")
            float distance = Vector2.Distance(transform.position, mTarget.position);

            if (distance < mFollowRange)
            {
                Vector3 directionTOGO = mTarget.position - transform.position;
                directionTOGO.Normalize();

                transform.position += directionTOGO * Time.deltaTime * mFollowSpeed;
            }

            //      Get distance by simple substraction.


        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("????");
        if (col.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Debug.Log("89");
            Destroy(col.gameObject);
            RedMonsterLife = RedMonsterLife - 0.5f;
            if (RedMonsterLife <= 0)
            {
                explosion.Play();
                Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Instantiate(Keys, transform.position, Quaternion.identity);
            }
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            col.gameObject.GetComponent<Life>().DeductHealth(0.05f);
        }
    }

    public void SetTarget(Transform target)
    {
        mTarget = target;
    }
}
