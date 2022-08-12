using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamLook : MonoBehaviour
{
    public float speedV;
    private float pV;
    // Update is called once per frame
    void Update()
    {
        RotateLook();
    }

    void RotateLook()
    {
        pV -= speedV * Input.GetAxis("Mouse Y");
        FixRotation();
        transform.localEulerAngles = new Vector3(pV, 0, 0);
    }

    void FixRotation()
    {
        if(pV > 60)
        {
            pV = 60;
        }
        else if (pV < -60)
        {
            pV = -60;
        }
    }
}
