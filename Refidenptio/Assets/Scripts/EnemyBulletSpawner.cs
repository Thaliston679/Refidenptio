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

    // Update is called once per frame
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
