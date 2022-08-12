using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(new Vector3(PlayerMove.Player.transform.position.x, transform.position.y, PlayerMove.Player.transform.position.z));
    }
}
