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
        }
    }

    public void OpenDoor()
    {
        door.SetTrigger("Open");
    }

    public void CloseDoor()
    {
        door.SetTrigger("Close");
    }
}
