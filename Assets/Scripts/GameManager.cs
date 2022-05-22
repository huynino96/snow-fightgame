using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public int P1_life;
    public int P2_life;

    public GameObject p1Wins;
    public GameObject p2Wins;

    public GameObject[] p1Stick;
    public GameObject[] p2Stick;

    public string mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(P1_life <= 0)
        {
            player1.SetActive(false);
            p2Wins.SetActive(true);
        }

        if (P2_life <= 0)
        {
            player2.SetActive(false);
            p1Wins.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(mainMenu);
        }
    }

    public void HurtP1()
    {
        P1_life -= 1;
        for(int i = 0; i < p1Stick.Length; i++)
        {
            if(P1_life > i)
            {
                p1Stick[i].SetActive(true);
            }
            else
            {
                p1Stick[i].SetActive(false);
            }
        }
    }

    public void InstantKillP1()
    {
        P1_life -= 5;
        for (int i = 0; i < p1Stick.Length; i++)
        {
            if (P1_life > i)
            {
                p1Stick[i].SetActive(true);
            }
            else
            {
                p1Stick[i].SetActive(false);
            }
        }
    }

    public void HurtP2()
    {
        P2_life -= 1;
        for(int i = 0; i < p2Stick.Length; i++)
        {
            if(P2_life > i)
            {
                p2Stick[i].SetActive(true);
            }
            else
            {
                p2Stick[i].SetActive(false);
            }
        }
    }

    public void InstantKillP2()
    {
        P2_life -= 5;
        for (int i = 0; i < p2Stick.Length; i++)
        {
            if (P2_life > i)
            {
                p2Stick[i].SetActive(true);
            }
            else
            {
                p2Stick[i].SetActive(false);
            }
        }
    }
}
