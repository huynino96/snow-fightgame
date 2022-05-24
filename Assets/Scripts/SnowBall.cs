using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{

    public float ballSpeed;

    public GameObject SnowballEffect;

    private PlayerController player1;
    private PlayerController player2;

    private Rigidbody2D theRB;
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        PlayerController playerController1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerController>();
        player1 = playerController1;

        PlayerController playerController2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();
        player2 = playerController2;

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
            StartCoroutine(player1.Knockback(0.02f, 350, player1.transform.position));

        }

        if(collision.tag == "Player2")
        {
            FindObjectOfType<GameManager>().HurtP2();
            StartCoroutine(player2.Knockback(0.02f, 350, player2.transform.position));

        }
        Instantiate(SnowballEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
