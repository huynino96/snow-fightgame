using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{

    public float ballSpeed;

    public GameObject SnowballEffect;

    public float speed = 100;

    private Rigidbody2D theRB;
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(ballSpeed * transform.localScale.x, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            FindObjectOfType<GameManager>().HurtP1();
           
        }

        if(collision.tag == "Player2")
        {
            FindObjectOfType<GameManager>().HurtP2();
            //Vector3 direction = (transform.position - collision.transform.position).normalized;
            //collision.GetComponent<Rigidbody2D>().AddForce(direction * speed);
        }
        Instantiate(SnowballEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
