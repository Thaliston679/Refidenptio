using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator door;
    public GameObject room;
    public bool activated = false;
    public int enemiesToUnlock;
    //public GameObject player;
    public GameManagerT gamaManagerT;
    public bool playerinDoor = false;
    public bool enemiesInDoor = false;
    public int qtdEnemiesInDoor = 0;

    private void Update()
    {
        //if (qtdEnemiesInDoor > 0) enemiesInDoor = true;
        //else enemiesInDoor = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerinDoor = true;
            if (gamaManagerT.defeatedEnemies >= enemiesToUnlock)
            {
                OpenDoor();
                if (!activated)
                {
                    room.SetActive(true);
                    activated = true;
                }
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            //qtdEnemiesInDoor++;
            if (gamaManagerT.defeatedEnemies >= enemiesToUnlock)
            {
                OpenDoor();
                if (!activated)
                {
                    room.SetActive(true);
                    activated = true;
                }
            }
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerinDoor = false;

            if (!enemiesInDoor)
            {
                CloseDoor();
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            //qtdEnemiesInDoor--;

            if (!playerinDoor)
            {
                CloseDoor();
            }
        }
    }

    public void OpenDoor()
    {
        door.SetBool("Close", false);
        door.SetBool("Open", true);
        /*if (door.GetBool("Close"))
        {
            door.SetBool("Close", false);
            door.SetBool("Open", true);
        }*/
    }

    public void CloseDoor()
    {
        door.SetBool("Open", false);
        door.SetBool("Close", true);
        /*if (door.GetBool("Open"))
        {
            door.SetBool("Open", false);
            door.SetBool("Close", true);
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInDoor = true;
        }
    }
}
