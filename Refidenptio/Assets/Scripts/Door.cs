using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator door;
    public GameObject room;
    public bool activated = false;
    /*
    public GameObject player;
    public GameObject gamaManagerT;
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OpenDoor();
            if (!activated)
            {
                room.SetActive(true);
                activated = true;
            }
        }
    }

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
