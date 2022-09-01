using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour
{
    public float delay;
    public float speedBullet;
    public float lifeTimeBullet;
    public float damageBullet;
    public int bulletType;
    private bool attacking = false;
    public GameObject bullet;

    public bool[] typeBulletPreset = { false, false, false, false, false, false }; //Valores predefinidos para projétis do inimigo

    private void Start()
    {
        if (typeBulletPreset[0]) //
        {
            /*delay = null;
            speedBullet = null;
            lifeTimeBullet = null;
            damageBullet = null;
            bulletType = null;*/
        }
        else if (typeBulletPreset[1]) // Entity
        {
            delay = 0.5f;
            speedBullet = 15;
            lifeTimeBullet = 2;
            damageBullet = 2;
            bulletType = 1;
        }
        else if (typeBulletPreset[2]) //
        {
            /*delay = null;
            speedBullet = null;
            lifeTimeBullet = null;
            damageBullet = null;
            bulletType = null;*/
        }
        else if (typeBulletPreset[3]) // Magecide
        {
            delay = 1;
            speedBullet = 0.25f;
            lifeTimeBullet = 8;
            damageBullet = 20;
            bulletType = 3;
        }
        else if (typeBulletPreset[4]) // Chaeyes
        {
            delay = 2;
            speedBullet = 1.5f;
            lifeTimeBullet = 4;
            damageBullet = 70;
            bulletType = 4;
        }
        else if (typeBulletPreset[5]) // Bat
        {
            delay = 4;
            speedBullet = 1;
            lifeTimeBullet = 4;
            damageBullet = 40;
            bulletType = 5;
        }
    }
    void Update()
    {
        if (!attacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        attacking = true;

        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<EnemyBullet>().speed = speedBullet;
        newBullet.GetComponent<EnemyBullet>().lifeTime = lifeTimeBullet;
        newBullet.GetComponent<EnemyBullet>().damage = damageBullet;
        newBullet.GetComponent<Animator>().SetInteger("bulletType", bulletType);

        yield return new WaitForSeconds(delay);
        attacking = false;
    }
}
