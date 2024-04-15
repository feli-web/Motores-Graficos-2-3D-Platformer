using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float fallForce;
    public Rigidbody rb;
    public CapsuleCollider col;
    public Animator animator;
    public Transform robotModel;
    float x;
    float z;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundMask;

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


        isGrounded = Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundMask);
        if (x != 0 || z != 0)
        {
            float targetAngle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;
            robotModel.rotation = Quaternion.Euler(0, targetAngle, 0);
        }

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Normalize the velocity so it doesn't move faster in diagonal
        Vector3 movement = new Vector3(x, 0f, z).normalized;

        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.Play("CharacterArmature|Jump");
        }
        if (rb.velocity.y < 0 )
        {
            rb.AddForce(Vector3.down * fallForce, ForceMode.Acceleration);
        }
    }
   
}
