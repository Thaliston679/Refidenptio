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
    private float randY;

    void Start()
    {
        Invoke("DisableBillBoard", 0.01f);
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, lifeTime);
        randY = Random.Range(0.425f, 0.875f);
    }

    void Update()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Force);

        if(transform.position.y > randY)
        {
            transform.position = new(transform.position.x, transform.position.y - 0.5f * Time.deltaTime, transform.position.z);
        }
    }

    public void DisableBillBoard()
    {
        GetComponent<Billboard>().enabled = false;
        //Adicionar método para rotacionar Y pelo valor passado
    }

    public float DoDamage()
    {
        return damage;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject, 0.01f);
    }*/
}
