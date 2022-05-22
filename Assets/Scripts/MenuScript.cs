using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string mainGameScene;

    public void StartGame()
    {
        SceneManager.LoadScene(mainGameScene);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
