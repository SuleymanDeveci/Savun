using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    public int hasar = 20;

    public float speed = 20f;


    void Start()
    {
        rb.velocity = transform.right * speed;
        hasar = 20;
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

       

        Destroy(gameObject);

    }


}
