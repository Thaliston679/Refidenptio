using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextHp : MonoBehaviour
{
    public int hp;

    private Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        hpText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string info = "HP: " + hp.ToString();
        hpText.text = info;
    }
}
