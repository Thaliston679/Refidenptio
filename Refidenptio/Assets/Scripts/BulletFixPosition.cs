using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFixPosition : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        /*
        Vector3 posCorrect = new(transform.position.x, transform.position.y, transform.position.z * 0.05f);
        transform.position += posCorrect;
        */

        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 currentPos = transform.position;
        Vector3 finalPos = player.transform.position;
        transform.position = Vector3.MoveTowards(currentPos, finalPos, 0.1f);
    }
}
