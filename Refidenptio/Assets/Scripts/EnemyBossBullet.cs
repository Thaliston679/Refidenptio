using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossBullet : MonoBehaviour
{
    public int bossState = 0;

    public float timeBossState = 3f;
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

    void Update()
    {
        TimerState();

        if (AttackBoss) TimerAttack();
    }

    void TimerState() // Temporizador para trocar entre os estados de ataque do boss
    {
        currentTimeBossState += 1 * Time.deltaTime;

        if(currentTimeBossState >= timeBossState)
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
                timeBossState = 3f;
                break;
            case 3:
                timeBossState = 2f;
                break;
            case 4:
                timeBossState = 2f;
                break;
            case 5:
                timeBossState = 4f;
                break;
            case 6:
                timeBossState = 5f;
                break;
            default:
                timeBossState = 2f;
                break;
        }
    }



    void BossState1()
    {
        speedBullet = 4f;
        lifeTimeBullet = 7f;
        damageBullet = 1f;
        bulletType = 1;

        timeAttackBoss = 1f;

        for (int i = 0; i <= 360; i += 30)
        {
            randRotateY = i;
            Attack();
        }
    }

    void BossState2()
    {
        speedBullet = 8f;
        lifeTimeBullet = 7f;
        damageBullet = 1f;
        bulletType = 0;

        timeAttackBoss = 0.5f;

        for (int i = 45; i < 360; i += 45)
        {
            randRotateY = i;
            Attack();
        }
    }

    void BossState3()
    {
        speedBullet = 2f;
        lifeTimeBullet = 7f;
        damageBullet = 1f;
        bulletType = 4;

        timeAttackBoss = 0.5f;

        for (int i = -60; i <= 60; i += 15)
        {
            randRotateY = i;
            Attack();
        }
    }

    void BossState4()
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

    void BossState5()
    {
        speedBullet = 1f;
        lifeTimeBullet = 10f;
        damageBullet = 30f;
        bulletType = 0;

        timeAttackBoss = 2f;

        for (int i = -90; i <= 90; i += 45)
        {
            randRotateY = i;
            Attack();
        }
    }

    void BossState6()
    {
        speedBullet = 2.5f;
        lifeTimeBullet = 7f;
        damageBullet = 5f;
        bulletType = 5;

        timeAttackBoss = 0.5f;

        for (int i = -60; i <= 60; i += 15)
        {
            randRotateY = i;
            Attack();
        }
    }

    public void Attack() // Instancia o projétil
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
