using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamLook : MonoBehaviour
{
    public float speedV;
    private float pV;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateLook();
    }

    void RotateLook()
    {
        pV -= speedV * Input.GetAxis("Mouse Y");
        transform.localEulerAngles = new Vector3(pV, 0, 0);
    }
}
