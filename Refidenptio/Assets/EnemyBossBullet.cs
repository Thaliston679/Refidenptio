using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossBullet : MonoBehaviour
{
    public int bossState;
    public float timeBossState = 0.5f;
    public float currentTimeBossState;

    public float currentTimeAttackBoss;
    public float timeAttackBoss;
    public bool AttackBoss;


    //Atributos do projétil
    public float speedBullet;
    public float lifeTimeBullet;
    public float damageBullet;
    public float randRotateY;
    public int bulletType;
    public GameObject bullet;

    void Update()
    {
        TimerState();

        //if (AttackBoss) TimerAttack();
    }

    void TimerState()
    {
        currentTimeBossState += 1 * Time.deltaTime;

        if(currentTimeBossState >= timeBossState)
        {
            currentTimeBossState = 0;
            BossStates();
        }
    }

    /*
    void TimerAttack()
    {
        currentTimeAttackBoss = 1 * Time.deltaTime;

        if (currentTimeAttackBoss >= timeAttackBoss)
        {
            
        }
    }
    */

    void BossStates()
    {
        bossState = Random.Range(0, 2);

        switch (bossState)
        {
            case 0:
                BossState0();
                break;
            case 1:
                BossState1();
                break;
            case 2:
                break;
        }
    }

    void BossState0()
    {
        speedBullet = 0.5f;
        lifeTimeBullet = 3f;
        damageBullet = 1f;
        bulletType = 1;

        for (int i = 0; i <= 360; i += 30)
        {
            randRotateY = i;
            Attack();
        }
    }

    void BossState1()
    {
        speedBullet = 2f;
        lifeTimeBullet = 2f;
        damageBullet = 1f;
        bulletType = 0;

        for (int i = 45; i < 360; i += 45)
        {
            randRotateY = i;
            Attack();
        }
    }

    public void Attack()
    {
        Debug.Log("Attack");
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<EnemyBullet>().speed = speedBullet;
        newBullet.GetComponent<EnemyBullet>().lifeTime = lifeTimeBullet;
        newBullet.GetComponent<EnemyBullet>().damage = damageBullet;
        newBullet.GetComponent<EnemyBullet>().randRotateY = randRotateY;
        newBullet.GetComponent<Animator>().SetInteger("bulletType", bulletType);
    }
}
