using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrap : MonoBehaviour
{
    Animator anim;
    [SerializeField] bool active = false;
    [SerializeField] float activeTime;
    [SerializeField] float activeCurrentTime;

    [SerializeField] float desactiveTime;
    [SerializeField] float desactiveCurrentTime;
    [SerializeField] bool canActive = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !active && canActive)
        {
            active = true;
            anim.SetTrigger("Active");
            activeCurrentTime = activeTime;
        }
    }

    private void Update()
    {
        if (active)
        {
            if (activeCurrentTime >= 0) activeCurrentTime -= Time.deltaTime;
        }
        if (activeCurrentTime < 0 && active)
        {
            active = false;
            desactiveCurrentTime = desactiveTime;
            canActive = false;
            anim.SetTrigger("Desactive");
        }

        if (!canActive)
        {
            if (desactiveCurrentTime >= 0) desactiveCurrentTime -= Time.deltaTime;
        }
        if (desactiveCurrentTime < 0 && !canActive)
        {
            canActive = true;
        }
    }
}
