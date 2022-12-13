using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveOnDistance : MonoBehaviour
{
    public GameObject obj;
    public bool objIsVisible;

    float timer;

    private void Start()
    {
        Invoke(nameof(DesactiveCristals), 0.1f);
    }

    private void Update()
    {
        if (objIsVisible) timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            if (obj != null) GetComponent<BoxCollider>().center = obj.transform.localPosition;
        }
    }

    void DesactiveCristals()
    {
        if (!objIsVisible) obj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            objIsVisible = true;
            if (obj != null) obj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (obj != null) GetComponent<BoxCollider>().center = obj.transform.localPosition;
            objIsVisible = false;
            if (obj != null) obj.SetActive(false);
        }
    }
}
