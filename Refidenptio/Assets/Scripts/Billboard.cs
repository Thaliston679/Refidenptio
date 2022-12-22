using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(player != null)
        {
            //Vector3 v3T = transform.position + player.transform.position * Vector3.forward;
            //v3T.y = transform.position.y;
            //transform.LookAt(v3T, Vector3.up);

            Vector3 LookDir = player.position;
            //child.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            transform.LookAt(new Vector3(LookDir.x, transform.position.y, LookDir.z));
        }
    }
}
