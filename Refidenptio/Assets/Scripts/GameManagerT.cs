using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerT : MonoBehaviour
{
    public UITextAmmo uITextAmmo;
    public PlayerWeapon playerWeapon;

    public PlayerCamLook pCamLoock;
    public PlayerCamRotation pCamRot;

    public UITextScore uITextScore;
    private int score;
    public float qtdAmmo;
    public float maxAmmo;

    public float playerHP = 100;
    public float playerHPMax = 100;

    public GameObject hpFill;
    public GameObject ammoFill;

    public int defeatedEnemies;

    public bool inGame = false;
    public bool pausedGame = false;
    public bool inConfigs = false;

    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject configMenu;

    private void Start()
    {
        EnableMouse();
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
            //Debug.Log(playerFill);
        }
        
    }

    public void AMMOBar()
    {
        if(maxAmmo != 0)
        {
            float playerFill = (qtdAmmo / maxAmmo);
            ammoFill.GetComponent<Image>().fillAmount = playerFill;
            //Debug.Log(playerFill);
        }
        
    }

    public void GameOver()
    {
        if(playerHP <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void DisableMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void EnableMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DisableCameraMovement()
    {
        pCamLoock.enabled = false;
        pCamRot.enabled = false;
        playerWeapon.enabled = false;
    }

    public void EnableCameraMovement()
    {
        pCamLoock.enabled = true;
        pCamRot.enabled = true;
        playerWeapon.enabled = true;
    }

    public void EnableConfig()
    {
        configMenu.SetActive(true);
        inConfigs = true;
    }

    public void DisableConfig()
    {
        configMenu.SetActive(false);
        inConfigs = false;
    }

    void FastProcess()
    {
        if (inGame)
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
    }

    public void EnablePause()
    {
        pausedGame = true;
        Time.timeScale = 0;
        EnableMouse();
        DisableCameraMovement();
        pauseMenu.SetActive(true);
    }

    public void DisablePause()
    {
        if (inConfigs && !inGame)
        {
            DisableConfig();
        }
        else if (inConfigs && inGame)
        {
            DisableConfig();
        }
        else
        {
            pausedGame = false;
            Time.timeScale = 1;
            DisableMouse();
            EnableCameraMovement();
            pauseMenu.SetActive(false);
        }
            
    }

    public void InGame(bool onOff)
    {
        inGame = onOff;
    }

    void PauseGame()
    {
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && inGame)
        {
            if (pausedGame)
            {
                DisablePause();
            }
            else
            {
                EnablePause();
            }
        }
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
