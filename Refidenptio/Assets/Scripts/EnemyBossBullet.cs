using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossBullet : MonoBehaviour
{
    public int bossState = 0;

    public float timeBossState = 1f;
    public float currentTimeBossState;

    public float timeAttackBoss = 0.5f;
    public float currentTimeAttackBoss;

    public bool AttackBoss;


    //Atributos do projétil
    public float speedBullet;
    public float lifeTimeBullet;
    public float damageBullet;
    public float randRotateY;
    public int bulletType;
    public GameObject bullet;

    public EnemyLifeAndDeath bossHP;

    public GameObject bulletMagecide;

    void Update()
    {
        TimerState();

        if (AttackBoss) TimerAttack();

        newAttacks();
    }

    void TimerState() // Temporizador para trocar entre os estados de ataque do boss
    {
        currentTimeBossState += 1 * Time.deltaTime;

        if (currentTimeBossState >= timeBossState)
        {
            currentTimeBossState = 0;
            //AttackBoss = false;
            SwitchBossState();
        }
    }

    void TimerAttack() // Temporizador para Spawnar novos projéteis do mesmo estado de ataque do boss
    {
        currentTimeAttackBoss += 1 * Time.deltaTime;

        if (currentTimeAttackBoss >= timeAttackBoss)
        {
            currentTimeAttackBoss = 0;
            string callAttack = "BossState" + bossState.ToString();
            Invoke(callAttack, 0);
        }
    }

    void SwitchBossState() // Troca o estado de ataque do boss
    {
        bossState = Random.Range(1, 7);

        switch (bossState)
        {
            case 1:
                timeBossState = 3f;
                break;
            case 2:
                timeBossState = 2f;
                break;
            case 3:
                timeBossState = 2f;
                break;
            case 4:
                timeBossState = 2f;
                break;
            case 5:
                timeBossState = 3f;
                break;
            case 6:
                timeBossState = 5f;
                break;
            default:
                timeBossState = 1f;
                break;
        }
    }



    void BossState1()//Ok
    {
        speedBullet = 4f;
        lifeTimeBullet = 7f;
        damageBullet = 20f;
        bulletType = 1;

        timeAttackBoss = 1f;

        for (int i = -90; i <= 90; i += 30)
        {
            randRotateY = i;
            Attack();
        }
    }

    void BossState2()//OK OK
    {
        speedBullet = 8f;
        lifeTimeBullet = 7f;
        damageBullet = 10f;
        bulletType = 0;

        timeAttackBoss = 0.5f;

        for (int i = -45; i < 45; i += 15)
        {
            randRotateY = i;
            Attack();
        }
    }

    void BossState3()
    {
        speedBullet = 2f;
        lifeTimeBullet = 7f;
        damageBullet = 30f;
        bulletType = 4;

        timeAttackBoss = 0.5f;

        for (int i = -45; i <= 45; i += 15)
        {
            randRotateY = i;
            Attack();
        }
    }

    void BossState4()//Ok
    {
        speedBullet = 3f;
        lifeTimeBullet = 7f;
        damageBullet = 10f;
        bulletType = 5;

        timeAttackBoss = 0.35f;

        for (int i = -90; i <= 90; i += 45)
        {
            randRotateY = i;
            Attack();
        }
    }

    void BossState5()//Ok OK
    {
        speedBullet = 1f;
        lifeTimeBullet = 10f;
        damageBullet = 50f;
        bulletType = 0;

        timeAttackBoss = 1.5f;

        for (int i = -60; i <= 60; i += 30)
        {
            randRotateY = i;
            Attack();
        }
    }

    void BossState6()//Ok morcegos
    {
        speedBullet = 2.5f;
        lifeTimeBullet = 7f;
        damageBullet = 40f;
        bulletType = 5;

        timeAttackBoss = 1.5f;

        for (int i = -30; i <= 30; i += 10)
        {
            randRotateY = i;
            Attack();
        }
    }

    public void Attack() // Instancia o projétil
    {
        Debug.Log("Attack");
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

        if (bossHP.enemyHP >= 21)
        {
            newBullet.GetComponent<EnemyBullet>().speed = speedBullet;
            newBullet.GetComponent<EnemyBullet>().damage = damageBullet;
        }
        else if (bossHP.enemyHP < 21 && bossHP.enemyHP >= 11)
        {
            newBullet.GetComponent<EnemyBullet>().speed = speedBullet * 1.25f;
            newBullet.GetComponent<EnemyBullet>().damage = damageBullet * 1.25f;
        }
        else if (bossHP.enemyHP < 11 && bossHP.enemyHP >= 6)
        {
            newBullet.GetComponent<EnemyBullet>().speed = speedBullet * 1.75f;
            newBullet.GetComponent<EnemyBullet>().damage = damageBullet * 1.75f;
        }
        else if (bossHP.enemyHP < 5)
        {
            newBullet.GetComponent<EnemyBullet>().speed = speedBullet * 2f;
            newBullet.GetComponent<EnemyBullet>().damage = damageBullet * 2f;
        }


        newBullet.GetComponent<EnemyBullet>().lifeTime = lifeTimeBullet;
        newBullet.GetComponent<EnemyBullet>().randRotateY = randRotateY;
        newBullet.GetComponent<Animator>().SetInteger("bulletType", bulletType);
    }

    public void newAttacks()
    {
        if (bossHP.enemyHP == 15)
        {
            bulletMagecide.SetActive(true);
        }
    }
}