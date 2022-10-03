using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossControl : MonoBehaviour
{
    public EnemyLifeAndDeath enemyLife;
    public GameObject endGame;
    public GameManagerT gameManagerT;

    private NavMeshAgent agent;
    public GameObject target;
    private Vector3 originPoint;


    private void Start()
    {
        originPoint = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

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

        CheckIdleRun();
    }

    public void CheckIdleRun()
    {
        if(enemyLife.enemyHP >= 45)
        {
            SetTargetOrigin();
        }
        else if (enemyLife.enemyHP < 45 && enemyLife.enemyHP >= 40)
        {
            SetTargetPlayer();
        }
        else if (enemyLife.enemyHP < 40 && enemyLife.enemyHP >= 35)
        {
            SetTargetOrigin();
        }
        else if (enemyLife.enemyHP < 35 && enemyLife.enemyHP >= 30)
        {
            SetTargetPlayer();
        }
        else if (enemyLife.enemyHP < 30 && enemyLife.enemyHP >= 25)
        {
            SetTargetOrigin();
        }
        else if (enemyLife.enemyHP < 25 && enemyLife.enemyHP >= 20)
        {
            SetTargetPlayer();
        }
        else if (enemyLife.enemyHP < 20 && enemyLife.enemyHP >= 15)
        {
            SetTargetOrigin();
        }
        else if (enemyLife.enemyHP < 15 && enemyLife.enemyHP >= 10)
        {
            agent.speed = 4;
            SetTargetOrigin();
        }
        else if (enemyLife.enemyHP < 10)
        {
            agent.speed = 5.5f;
            SetTargetPlayer();
        }
    }

    public void SetTargetOrigin()
    {
        agent.SetDestination(originPoint);
    }

    public void SetTargetPlayer()
    {
        agent.SetDestination(target.transform.position);
    }

    public NavMeshAgent GetAgent()
    {
        return agent;
    }
}
