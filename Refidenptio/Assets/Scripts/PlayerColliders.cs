using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliders : MonoBehaviour
{
    public PlayerWeapon playerWeapon;
    public GameManagerT gameManagerT;
    public PlayerMove playerMove;

    public GameObject damageEffect;
    public bool onDamage = false;

    public GameObject respawnFlower;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            if(gameManagerT.qtdAmmo < gameManagerT.maxAmmo)
            {
                playerWeapon.GetAmmo(10);
                Instantiate(respawnFlower, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("HP"))
        {
            if(gameManagerT.playerHP < gameManagerT.playerHPMax)
            {
                gameManagerT.GetHP(10);
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            if (!onDamage)
            {
                StartCoroutine(DamagePlayer(other.gameObject.GetComponent<EnemyBullet>().damage));
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!onDamage)
            {
                StartCoroutine(DamagePlayer(10));
            }
        }
    }

    public IEnumerator DamagePlayer(float damage)
    {
        onDamage = true;
        damageEffect.SetActive(true);

        gameManagerT.playerHP -= damage;

        playerMove.anim.SetTrigger("Damage");

        yield return new WaitForSeconds(0.5f);

        damageEffect.SetActive(false);
        onDamage = false;
    }
}
