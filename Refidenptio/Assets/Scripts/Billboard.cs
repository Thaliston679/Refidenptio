using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        if(PlayerMove.Player != null)
        {
            transform.LookAt(new Vector3(PlayerMove.Player.transform.position.x, transform.position.y, PlayerMove.Player.transform.position.z));
        }
    }
}
