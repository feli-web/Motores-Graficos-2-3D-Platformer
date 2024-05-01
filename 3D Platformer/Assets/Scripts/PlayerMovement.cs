using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody rb;
    public CapsuleCollider col;
    public Animator animator;
    public Transform robotModel;
    float x;
    float z;
    public bool isGrounded;
    public bool isKilling;
    public Transform groundCheck;
    public LayerMask groundMask;
    public LayerMask killMask;

    void Start()
    {

    }
    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        if (x != 0 || z != 0)
        {
            animator.SetFloat("Speed", 1); 
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }


        animator.SetBool("IsGrounded", isGrounded);

        if (rb.velocity.y <= 0)
        {
            animator.SetBool("IsFalling", true);
        }
        else
        {
            animator.SetBool("IsFalling", true);
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
        isKilling = Physics.CheckSphere(groundCheck.position, 0.4f, killMask);
        if (x != 0 || z != 0)
        {
            float targetAngle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;
            robotModel.rotation = Quaternion.Euler(0, targetAngle, 0);
        }

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(x * speed, rb.velocity.y, z * 0);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            animator.Play("CharacterArmature|Jump");
        }
    }
   
}
