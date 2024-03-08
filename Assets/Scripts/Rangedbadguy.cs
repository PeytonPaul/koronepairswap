using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Rangedbadguy : MonoBehaviour
{
    private float moveSpeed;
    private bool moveRight;

    //Give the enemy a lifetime variable and set it 7.5 by default
    public float lifeTime = 7.5f;

    private void Start()
    {
        moveSpeed = 2f;
        moveRight = true;

        //Set it to destroy after lifetime on start()
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        if (transform.position.x > 7f)
        {
            moveRight = false;
        }
        else if (transform.position.x < -7f)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,
            transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime,
            transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            LevelManager.manager.IncreaseScore(1);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
