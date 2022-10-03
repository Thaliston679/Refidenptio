using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform aimC;
    public float qtdAmmo = 30;
    public float maxAmmo = 30;
    private bool canShoot = true;

    public Animator animator;

    public GameObject bulletEffectPrefab;
    public GameObject particleDamageEffect;
    public GameObject aimImage;


    //public bool aiming = false;

    public GameManagerT gameManagerT;

    //Accurate
    public float accurateShot;
    public float totalShots;

    //private GameManagerT gameManagerT;

    private void Start()
    {
        //gameManagerT = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerT>();
    }

    private void Update()
    {
        if(!gameManagerT.pausedGame) Shoot();
        //ReloadAmmo();
        AmmoLimit();
        //Cheat();// !!!!!!!!!- Remover -!!!!!!!!!
    }

    /*public void Cheat()
    {
        if(Input.GetKey(KeyCode.C) *//*&& Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.T)*//* && Input.GetKey(KeyCode.Keypad9))
        {
            maxAmmo = 9999;
            qtdAmmo = maxAmmo;
        }
    }*/

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Hit();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Aim(true);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            Aim(false);
        }
    }

    public void Aim(bool active)
    {
        PlayerCamLook pCamL = gameObject.GetComponent<PlayerCamLook>();
        PlayerCamRotation pCamR = gameObject.GetComponentInParent<PlayerCamRotation>();
        PlayerMove pMove = gameObject.GetComponentInParent<PlayerMove>();

        if (active)
        {
            pCamL.speedV = 0.75f;
            pCamR.speedH = 1;
            pMove.speedX = 1;
            pMove.speedZ = 1;
            aimImage.SetActive(true);
        }
        else
        {
            pCamL.speedV = 1.5f;
            pCamR.speedH = 2;
            pMove.speedX = 2;
            pMove.speedZ = 2;
            aimImage.SetActive(false);
        }
    }

    /*
    void ReloadAmmo()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            qtdAmmo = maxAmmo;
        }
    }
    */

    public void GetAmmo(int a)
    {
        qtdAmmo += a;
    }

    void AmmoLimit()
    {
        if(qtdAmmo > maxAmmo)
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
            Debug.Log("Sem muni��o");
            return false;
        }

    }*/

    public bool Hit()
    {
        if (qtdAmmo > 0)
        {
            StartCoroutine(Shooting());

            animator.SetTrigger("Atk");

            qtdAmmo--;
            totalShots++;
            RaycastHit hit;

            if (Physics.Raycast(aimC.position, aimC.TransformDirection(Vector3.forward), out hit, 40f, 7 /*Mathf.Infinity*/ ))
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

                        Instantiate(particleDamageEffect, hit.point, Quaternion.identity);
                    }
                    // ------------------------------------------------------------------------------------------------
                    // ------------------------------------------------------------------------------------------------
                    accurateShot++;
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
            Debug.Log("Sem muni��o");
            return false;
        }

    }

    IEnumerator Shooting()
    {
        canShoot = false;

        yield return new WaitForSeconds(0.3f);

        canShoot = true;
    }
}
