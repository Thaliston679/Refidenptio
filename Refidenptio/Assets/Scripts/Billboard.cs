using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform player;
    [SerializeField] private Transform child;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(player != null)
        {
            //child.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z), Vector3.up);
        }
    }
}
