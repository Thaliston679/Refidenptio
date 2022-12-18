using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBullet : MonoBehaviour
{
    //Assignables
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    //Stats
    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    //Damage
    public int explosionDamage;
    public float explosionRange;

    //Lifetime
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

    int collisions;
    PhysicMaterial physics_mat;

    bool checkExplosion = false;

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        //quando explodir:
        if (collisions > maxCollisions) Explode();

        //Contagem regressiva da vida
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Explode();
    }

    private void Explode()
    {
        if (!checkExplosion)
        {
            checkExplosion = true;
            //Instantiate explosion
            if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

            //Check for enemies 
            Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
            for (int i = 0; i < enemies.Length; i++)
            {
                //Get component of enemy and call Take Damage

                //Just an example!
                ///enemies[i].GetComponent<ShootingAi>().TakeDamage(explosionDamage);
            }

            //Adicione um pequeno atraso, apenas para garantir que tudo funcione bem
            Invoke("Delay", 0.05f);
        }
        
    }
    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Contagem de colisões
                collisions++;

        //Explode se a bala atingir um inimigo diretamente e explodiOnTouch estiver ativado
        if (collision.collider.CompareTag("Enemy") && explodeOnTouch) Explode();
    }

    private void Setup()
    {
        //Create a new Physic material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Assign material to collider
        GetComponent<SphereCollider>().material = physics_mat;

        //Set gravity
        rb.useGravity = useGravity;
    }

    /// Just to visualize the explosion range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
