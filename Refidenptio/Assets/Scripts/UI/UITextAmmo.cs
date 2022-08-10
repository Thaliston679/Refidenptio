using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITextAmmo : MonoBehaviour
{
    public int qtdAmmo;
    public int maxAmmo;

    private TextMeshProUGUI ammoText;

    //private Text ammoText;
    // Start is called before the first frame update
    void Start()
    {
        ammoText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string info = "AMMO: " + qtdAmmo.ToString() + " / " + maxAmmo.ToString();
        ammoText.text = info;
    }
}
