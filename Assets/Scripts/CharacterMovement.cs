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

    public AudioSource soundEffect;

    public AudioClip jump;
    public AudioClip fall;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

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
            soundEffect.clip = fall;
            soundEffect.Play();
        }
        else
        {
            animator.SetBool("Falling", false);
        }

        animator.SetFloat("Speed", Mathf.Abs(dirX));

        if (Input.GetKeyDown("up") && isTouchingGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, 7.5f, 0);
            soundEffect.clip = jump;
            soundEffect.Play();
        }

        if (Input.GetKeyDown("left"))
        {
            sr.flipX = false;
            grabDetector.transform.position = new Vector3(GetComponent<Transform>().position.x - 1f, grabDetector.transform.position.y, grabDetector.transform.position.z);
            grabHolder.transform.position = new Vector3(GetComponent<Transform>().position.x - 1f, grabHolder.transform.position.y, grabHolder.transform.position.z);
            rb.velocity = new Vector3(-5f, rb.velocity.y, 0);
        }

        if (Input.GetKeyDown("right"))
        {
            sr.flipX = true;
            grabDetector.transform.position = new Vector3(GetComponent<Transform>().position.x + 1f, grabDetector.transform.position.y, grabDetector.transform.position.z);
            grabHolder.transform.position = new Vector3(GetComponent<Transform>().position.x + 1f, grabHolder.transform.position.y, grabHolder.transform.position.z);
            rb.velocity = new Vector3(5f, rb.velocity.y, 0);
        }
    }

}
