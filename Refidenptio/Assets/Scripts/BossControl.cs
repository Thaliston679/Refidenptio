using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    public EnemyLifeAndDeath enemyLife;
    public GameObject endGame;
    public GameManagerT gameManagerT;

    private void Update()
    {
        if(enemyLife.enemyHP <= 0)
        {
            gameManagerT.inGame = false;
            gameManagerT.EnableMouse();
            gameManagerT.DisableCameraMovement();
            Time.timeScale = 0;
            endGame.SetActive(true);
        }
    }
}
