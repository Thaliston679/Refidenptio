using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamRotation : MonoBehaviour
{
    public float speedH;
    private float pH;

    // Update is called once per frame
    void Update()
    {
        TurnSides();
    }

    void TurnSides()
    {
        pH += speedH * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0, pH, 0);
    }

    
}
