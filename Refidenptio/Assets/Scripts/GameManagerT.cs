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
    public int qtdAmmo;
    public int maxAmmo;

    public float playerHP = 100;
    public float playerHPMax = 100;

    public GameObject hpFill;

    public int defeatedEnemies;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        uITextAmmo.qtdAmmo = playerWeapon.qtdAmmo;
        uITextAmmo.maxAmmo = playerWeapon.maxAmmo;
        uITextScore.score = score;

        HPLimit();
        HPBar();
        GameOver();

        qtdAmmo = playerWeapon.qtdAmmo;
        maxAmmo = playerWeapon.maxAmmo;
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
        float playerFill = (playerHP / 100);
        hpFill.GetComponent<Image>().fillAmount = playerFill;
        Debug.Log(playerFill);
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
}
