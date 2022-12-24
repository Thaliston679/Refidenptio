using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform player;
    public bool rotY;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("CinemachineTarget").transform;
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

            float posY;
            if (rotY) posY = player.transform.position.y;
            else posY = transform.position.y;

            transform.LookAt(new Vector3(LookDir.x, posY, LookDir.z));
        }
    }
}
