using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class badguy : MonoBehaviour
{
    private Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;

    //Give the enemy a lifetime variable and set it 7.5 by default
    public float lifeTime = 7.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Set it to destroy after lifetime on start()
        Destroy(gameObject, lifeTime);

        //Cache a referece to the target using the instance of the playerscript
        target = playerscript.instance.transform;
    }

    private void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void GetTarget()
    {
        //Instead of using FindGameObjectWithTag, I made the Players script an instance
        //and instead set it find the transform of that instance if its not equal to null
        if (target != null)
        {
            target = playerscript.instance.transform;
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg
        - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.manager.GameOver();
            //Destroy(other.gameObject);
            target = null;
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            LevelManager.manager.IncreaseScore(1);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
