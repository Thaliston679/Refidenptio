using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliders : MonoBehaviour
{
    public PlayerWeapon playerWeapon;
    public GameManagerT gameManagerT;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            playerWeapon.GetAmmo(10);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("HP"))
        {
            gameManagerT.GetHP(10);
            Destroy(other.gameObject);
        }
    }
}
