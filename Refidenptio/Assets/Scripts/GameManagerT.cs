using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerT : MonoBehaviour
{
    public UITextAmmo uITextAmmo;
    public PlayerWeapon playerWeapon;

    public PlayerCamLook pCamLoock;
    public PlayerCamRotation pCamRot;

    public PlayerColliders playerColliders;

    public UITextScore uITextScore;
    private int score;
    [SerializeField]
    private int totalScore = 947;
    public float qtdAmmo;
    public float maxAmmo;

    private float accurate;

    public float playerHP = 100;
    public float playerHPMax = 100;

    public GameObject hpFill;
    public GameObject ammoFill;

    public int defeatedEnemies;
    [SerializeField]
    private int totalEnemies = 185;

    public bool inGame = false;
    public bool pausedGame = false;
    public bool inConfigs = false;

    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject configMenu;
    public GameObject gameOverMenu;
    public GameObject statistics;

    public float healing = 0; //Em 5s restaura 1HP

    private float secondsTimer;
    private float minutesTimer;

    private void Start()
    {
        EnableMouse();
        //AccountantTotalScore();
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

        //FastProcess();
        PauseGame();

        //Cheat();// !!!!!!!!!- Remover -!!!!!!!!!
        AutoHeal();

        //Estat�sticas
        CheckStatistics();
        if (inGame)
        {
            Timer();
        }
    }

    //N�o funcionou porque os inimigos devem estar ativos quando o c�digo for executar (Existe algum meio de executar mesmo com eles desativados?)
    void AccountantTotalScore()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
           totalScore += enemy.GetComponent<EnemyLifeAndDeath>().enemyScoreValue;
        }
    }

    void Timer()
    {
        secondsTimer += Time.deltaTime;
        if(secondsTimer >= 60)
        {
            secondsTimer = 0;
            minutesTimer++;
        }
    }

    public void AutoHeal()
    {
        if(playerHP < playerHPMax && healing <= 5)
        {
            healing += Time.deltaTime;
        }
        if(playerHP < playerHPMax && healing >= 5)
        {
            healing = 0;
            playerHP++;
        }
    }

    /*public void Cheat()
    {
        if (Input.GetKey(KeyCode.C) *//*&& Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.T)*//* && Input.GetKey(KeyCode.Keypad8))
        {
            defeatedEnemies = 184;
        }
    }*/

    public void Killing(int enemyScore)
    {
        score += enemyScore;
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
        if(playerHP <= 0 && inGame)
        {
            inGame = false;
            EnableMouse();
            DisableCameraMovement();
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
        }
    }

    public void GameContinue()
    {
        playerWeapon.qtdAmmo = playerWeapon.maxAmmo;
        playerHP = playerHPMax;
        Time.timeScale = 1;
        DisableMouse();
        EnableCameraMovement();
        gameOverMenu.SetActive(false);
        playerColliders.DamagePlayer(0);
        inGame = true;

        GameObject findBossGO = GameObject.FindGameObjectWithTag("Enemy");
        EnemyLifeAndDeath findBoss = findBossGO.GetComponent<EnemyLifeAndDeath>();
        if(findBoss.enemyScoreValue == 100)
        {
            findBoss.enemyHP = 50;
            findBossGO.GetComponent<BossControl>().GetAgent().speed = 2;
        }
    }

    public void GameRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
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

    public void CheckStatistics()
    {
        //Time
        //DefeatedEnemies
        //Accurate
        accurate = (int)(100 / (playerWeapon.totalShots / playerWeapon.accurateShot));

        //Penitence
        //score;

        //"++"
        statistics.GetComponent<TextMeshProUGUI>().text = "Inimigos derrotados: "+defeatedEnemies+" / "+totalEnemies+"\nPenit�ncia: "+score+" / "+totalScore+ " \nPrecis�o: "+accurate+ "%\n Tempo de conclus�o: "+ (int)minutesTimer + ":" + (int)secondsTimer;
    }
}
