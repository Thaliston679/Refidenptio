using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform aimC;
    public int qtdAmmo;
    public int maxAmmo;

    public Animator animator;

    public GameObject bulletEffectPrefab;

    //private GameManagerT gameManagerT;

    private void Start()
    {
        //gameManagerT = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerT>();
    }

    private void Update()
    {
        Shoot();
        ReloadAmmo();
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Hit();
        }
    }

    void ReloadAmmo()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            qtdAmmo = maxAmmo;
        }
    }




    /*public bool Hit()
    {
        if(qtdAmmo > 0)
        {
            animator.SetTrigger("Atk");

            qtdAmmo--;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f *//*Mathf.Infinity*//* ))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                if (hit.collider.CompareTag("Enemy"))
                {
                    Destroy(hit.collider.gameObject);
                }

                //Colocar isso no Start para economizar processamento
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerT>().Killing(1);

                Debug.Log("Tiro certo");
                Instantiate(bulletEffectPrefab, hit.point, Quaternion.identity);
                return true;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Tiro errado");
                return false;
            }
        }

        else
        {
            Debug.Log("Sem munição");
            return false;
        }

    }*/

    public bool Hit()
    {
        if (qtdAmmo > 0)
        {
            animator.SetTrigger("Atk");

            qtdAmmo--;
            RaycastHit hit;

            if (Physics.Raycast(aimC.position, aimC.TransformDirection(Vector3.forward), out hit, 20f /*Mathf.Infinity*/ ))
            {
                Debug.DrawRay(aimC.position, aimC.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                if (hit.collider.CompareTag("Enemy"))
                {
                    //Destroy(hit.collider.gameObject);

                    // ------------------------------------------------------------------------------------------------
                    // ------------------------------------------------------------------------------------------------
                    EnemyLifeAndDeath EnemyHpControl = hit.collider.gameObject.GetComponent<EnemyLifeAndDeath>();
                    EnemyHpControl.SetEnemyHp(EnemyHpControl.GetEnemyHp() - 1);
                    if (EnemyHpControl.GetEnemyHp() >= 1)
                    {
                        SpriteRenderer img = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                        img.color = Color.red;
                        // OU //img.color = Color.red/black;
                        EnemyHpControl.SetSelfTimerDamage(0);
                        EnemyHpControl.SetOnDamage(true);
                    }
                    // ------------------------------------------------------------------------------------------------
                    // ------------------------------------------------------------------------------------------------

                    //gameManagerT.Killing(1);

                }

                Debug.Log("Tiro certo");
                Instantiate(bulletEffectPrefab, hit.point, Quaternion.identity);
                return true;
            }
            else
            {
                Debug.DrawRay(aimC.position, aimC.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Tiro errado");
                return false;
            }
        }

        else
        {
            Debug.Log("Sem munição");
            return false;
        }

    }
}
