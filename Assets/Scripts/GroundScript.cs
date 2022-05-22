using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public GameObject SnowballEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            FindObjectOfType<GameManager>().InstantKillP1();
        }

        if (collision.tag == "Player2")
        {
            FindObjectOfType<GameManager>().InstantKillP2();
        }
        Instantiate(SnowballEffect, transform.position, transform.rotation);
        //Destroy(gameObject);
    }
}
