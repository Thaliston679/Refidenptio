using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Intro : MonoBehaviour
{
    public bool NextScene = false;
    public GameObject intro;
    public GameObject level1;

    void Start()
    {
        //if (NextScene) GoToLevel();
        if (NextScene) GoToMainMenu();
    }

    void Update()
    {
        FastForward();
    }

    public void FastForward()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 20;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            Time.timeScale = 1;
        }

    }

    public void GoToMainMenu()
    {
        
        SceneManager.LoadScene(1);
        
    }

    public void GoToLevel()
    {
        intro.SetActive(false);
        level1.SetActive(true);
    }
}
