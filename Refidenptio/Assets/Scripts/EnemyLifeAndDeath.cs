using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeAndDeath : MonoBehaviour
{
    public int enemyHP;
    public int enemyScoreValue;
    private float selfTimeDamage = 0;
    private bool onDamage = false;

    private GameManagerT gameManagerT;

    public GameObject deadBodyGO;

    private void Start()
    {
        gameManagerT = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerT>();
    }

    void Update()
    {
        if (enemyHP <= 0)
        {
            gameManagerT.Killing(enemyScoreValue);
            gameManagerT.defeatedEnemies++;
            GenerateDeadBody();
            Destroy(this.gameObject, 0.01f);
            Debug.Log(gameManagerT.defeatedEnemies);
            //Instanciar corpo morto
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

    public void GenerateDeadBody()
    {
        Vector3 deadBodyPos = new(transform.position.x, -0.5f, transform.position.z);
        Instantiate(deadBodyGO, deadBodyPos, Quaternion.identity);
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
