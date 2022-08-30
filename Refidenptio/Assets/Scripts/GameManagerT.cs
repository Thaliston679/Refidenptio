using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerT : MonoBehaviour
{
    public UITextAmmo uITextAmmo;
    public PlayerWeapon playerWeapon;

    public UITextScore uITextScore;
    private int score;
    public float qtdAmmo;
    public float maxAmmo;

    public float playerHP = 100;
    public float playerHPMax = 100;

    public GameObject hpFill;
    public GameObject ammoFill;

    public int defeatedEnemies;

    public bool pausedGame = false;

    private void Start()
    {
        AtivarMouse();
    }

    // Update is called once per frame
    void Update()
    {
        uITextAmmo.qtdAmmo = playerWeapon.qtdAmmo;
        uITextAmmo.maxAmmo = playerWeapon.maxAmmo;
        uITextScore.score = score;

        HPLimit();
        GameOver();

        HPBar();
        AMMOBar();

        qtdAmmo = playerWeapon.qtdAmmo;
        maxAmmo = playerWeapon.maxAmmo;

        FastProcess();
        PauseGame();
    }

    public void Killing(int enemyScore)
    {
        score = score + enemyScore;
    }

    public void GetHP(int a)
    {
        playerHP += a;
    }

    public void HPLimit()
    {
        if(playerHP > playerHPMax)
        {
            playerHP = playerHPMax;
        }
    }

    public void HPBar()
    {
        if(playerHPMax != 0)
        {
            float playerFill = (playerHP / playerHPMax);
            hpFill.GetComponent<Image>().fillAmount = playerFill;
            Debug.Log(playerFill);
        }
        
    }

    public void AMMOBar()
    {
        if(maxAmmo != 0)
        {
            float playerFill = (qtdAmmo / maxAmmo);
            ammoFill.GetComponent<Image>().fillAmount = playerFill;
            Debug.Log(playerFill);
        }
        
    }

    public void GameOver()
    {
        if(playerHP <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void DesativarMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void AtivarMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    void FastProcess()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Time.timeScale = 20;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            Time.timeScale = 1;
        }
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pausedGame)
            {
                pausedGame = false;
                Time.timeScale = 0;
                DesativarMouse();
            }
            else
            {
                pausedGame = true;
                Time.timeScale = 1;
                AtivarMouse();
            }
        }
    }
}
