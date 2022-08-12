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

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Hit();
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

            if (Physics.Raycast(aimC.position, aimC.TransformDirection(Vector3.forward), out hit, 10f /*Mathf.Infinity*/ ))
            {
                Debug.DrawRay(aimC.position, aimC.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

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
