using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyBullet : MonoBehaviour
{
    public float lifeTime;
    public float speed;
    public float damage;
    public Billboard billboard;
    private Rigidbody rb;

    void Start()
    {
        Invoke("DisableBillBoard", 0.1f);
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Force);

        if(transform.position.y > 0.55f)
        {
            transform.position = new(transform.position.x, transform.position.y - 0.5f * Time.deltaTime, transform.position.z);
        }
    }

    public void DisableBillBoard()
    {
        GetComponent<Billboard>().enabled = false;
    }

    public float DoDamage()
    {
        return damage;
    }
}
