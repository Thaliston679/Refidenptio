using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossBullet : MonoBehaviour
{
    private int bossState;
    private float timeBossState;
    private float currentTimeBossState;

    private float currentTimeAttackBoss;
    private float timeAttackBoss;
    private bool AttackBoss;

    private void Update()
    {
        TimerState();
    }

    void TimerState()
    {
        currentTimeBossState = 1 * Time.deltaTime;

        if(currentTimeBossState >= timeBossState)
        {
            BossStates();
        }
    }

    void BossStates()
    {
        Random.Range(0, 1);

        switch (bossState)
        {
            case 0:
                BossState0();
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }

    void BossState0()
    {

    }
}
