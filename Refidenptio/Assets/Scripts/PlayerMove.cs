using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    public float speedX;
    public float speedZ;
    public float speed = 1;
    public float jumpForce;
    public bool isGrounded = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Run();
        Jump();
    }

    void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * speedX * speed;
        float moveZ= Input.GetAxisRaw("Vertical") * speedZ * speed;


        Vector3 posCorrect = (transform.right * moveX) + (transform.forward * moveZ);

        rb.velocity = new Vector3(posCorrect.x, rb.velocity.y, posCorrect.z);
        if(rb.velocity.x != 0 || rb.velocity.z != 0)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2.5f;
        }
        else
        {
            speed = 1;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(rb.velocity.x, jumpForce, rb.velocity.z, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
