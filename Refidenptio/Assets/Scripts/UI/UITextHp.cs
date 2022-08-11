using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITextHp : MonoBehaviour
{
    public int hp;

    private TextMeshProUGUI hpText;
    // Start is called before the first frame update
    void Start()
    {
        hpText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string info = "HP: " + hp.ToString();
        hpText.text = info;
    }
}
