using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public GameObject grabDetector;
    public GameObject grabHolder;
    public Animator animator;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;

    public Vector2 verticalV; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isTouchingGround)
        {
            animator.SetBool("Ground", true);
        }
        else
        {
            animator.SetBool("Ground", false);
        }

        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        if(rb.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Falling", false);
        }

        animator.SetFloat("Speed", Mathf.Abs(dirX));

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Change", !animator.GetBool("Change"));

        }

        if (Input.GetKeyDown("up") && isTouchingGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, 7.5f, 0);
        }

        if (Input.GetKeyDown("left"))
        {
            sr.flipX = false;
            grabDetector.transform.position = new Vector3(GetComponent<Transform>().position.x - 1f, grabDetector.transform.position.y, grabDetector.transform.position.z);
            grabHolder.transform.position = new Vector3(GetComponent<Transform>().position.x - 0.2f, grabHolder.transform.position.y, grabHolder.transform.position.z);
            rb.velocity = new Vector3(-5f, rb.velocity.y, 0);
        }

        if (Input.GetKeyDown("right"))
        {
            sr.flipX = true;
            grabDetector.transform.position = new Vector3(GetComponent<Transform>().position.x + 1f, grabDetector.transform.position.y, grabDetector.transform.position.z);
            grabHolder.transform.position = new Vector3(GetComponent<Transform>().position.x + 0.2f, grabHolder.transform.position.y, grabHolder.transform.position.z);
            rb.velocity = new Vector3(5f, rb.velocity.y, 0);
        }

    }

}
