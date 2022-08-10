using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerT : MonoBehaviour
{
    public UITextAmmo uITextAmmo;
    public PlayerWeapon playerWeapon;

    public UITextScore uITextScore;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uITextAmmo.qtdAmmo = playerWeapon.qtdAmmo;
        uITextAmmo.maxAmmo = playerWeapon.maxAmmo;
        uITextScore.score = score; 
    }

    public void Killing(int enemyScore)
    {
        score = score + enemyScore;
    }
}
