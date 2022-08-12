using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private GameObject player;
    public float speedZombie;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 finalPos = player.transform.position;
        transform.position = Vector3.MoveTowards(currentPos, finalPos, speedZombie);

        Vector3 lookAt = new Vector3(finalPos.x, transform.position.y, finalPos.z);

        //transform.LookAt(lookAt);
    }
}
