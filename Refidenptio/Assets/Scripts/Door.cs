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

    public float countDownEnemyInDoor;

    private void Start()
    {
        door.SetBool("Close", true);
    }

    private void Update()
    {
        //if (qtdEnemiesInDoor > 0) enemiesInDoor = true;
        //else enemiesInDoor = false;
        CheckOpenCloseDoor();
        CheckCountDownEnemyInDoor();
    }

    public void CheckCountDownEnemyInDoor()
    {
        countDownEnemyInDoor -= Time.deltaTime;

        if(countDownEnemyInDoor <= 0)
        {
            countDownEnemyInDoor = 0;
            enemiesInDoor = false;
        }
    }

    public void CheckOpenCloseDoor()
    {
        if((enemiesInDoor || playerinDoor) && activated)
        {
            bool getDoorState = door.GetBool("Close");
            if (getDoorState)
            {
                OpenDoor();
            }
        }
        if(!enemiesInDoor && !playerinDoor && activated)
        {
            bool getDoorState = door.GetBool("Open");
            if (getDoorState)
            {
                CloseDoor();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerinDoor = true;
            if (gamaManagerT.defeatedEnemies >= enemiesToUnlock)
            {
                //OpenDoor();
                if (!activated)
                {
                    room.SetActive(true);
                    activated = true;
                }
            }
        }

        /*
        if (other.gameObject.CompareTag("DeathEnemy"))
        {
            qtdEnemiesInDoor += 50;
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
        */
        /*
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
        */
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerinDoor = false;

            if (!enemiesInDoor)
            {
                //CloseDoor();
            }
        }

        /*
        if (other.gameObject.CompareTag("Enemy"))
        {
            //qtdEnemiesInDoor--;

            if (!playerinDoor)
            {
                CloseDoor();
            }
        }
        */
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
            countDownEnemyInDoor = 1;
        }/*
        else
        {
            enemiesInDoor = false;
        }*/
    }
}
