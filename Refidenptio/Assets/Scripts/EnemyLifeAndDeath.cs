using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeAndDeath : MonoBehaviour
{
    public int enemyHP;
    private float selfTimeDamage = 0;
    private bool onDamage = false;

    private void Start()
    {

    }

    void Update()
    {
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
            //Aumentar em 1 o contador de inimigos mortos
        }
        TimerDamage();
    }

    void TimerDamage()
    {
        if (selfTimeDamage < 1)
        {
            selfTimeDamage += Time.deltaTime;
        }
        if (onDamage)
        {
            if (selfTimeDamage > 0.2f)
            {
                SpriteRenderer img = gameObject.GetComponent<SpriteRenderer>();
                img.color = Color.white;

                selfTimeDamage = 0;

                onDamage = false;
            }
        }

    }

    public void SetEnemyHp(int i)
    {
        enemyHP = i;
    }

    public int GetEnemyHp()
    {
        return enemyHP;
    }

    public void SetSelfTimerDamage(float i)
    {
        selfTimeDamage = i;
    }

    public void SetOnDamage(bool i)
    {
        onDamage = i;
    }
}
