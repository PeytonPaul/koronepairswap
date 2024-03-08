using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bullet : MonoBehaviour
{

    [Range(1, 10)]
    [SerializeField] private float speed = 10f;

    /*[Range(1, 10)]
    [SerializeField] private float lifeTime = 3f;*/

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnBecameInvisible()
    {
        //I Used OnBecameInvisible on the Players bullets and commented out the Destroy() function in Start which 
        //will avoid having to do time calculations and calling Destroy() on start each time
        Destroy(gameObject);
    }
}
