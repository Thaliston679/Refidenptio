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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
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

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
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
    */

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CloseDoor();
            Debug.Log("Fechou");
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
}
