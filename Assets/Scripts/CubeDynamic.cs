using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDynamic : MonoBehaviour
{

    public GameObject player;
    public bool worldStatus;
    //public Camera camera;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    public bool touched;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(GetComponent<Rigidbody2D>().OverlapCollider );
        worldStatus = false;
        //distToGround = GetComponent<Rigidbody2D>().collisionDetectionMode. collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {

        isTouchingGround = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

        if (isTouchingGround)
        {
            worldStatus = !worldStatus;
        }

        //if (worldStatus)
        //{
        //    camera.backgroundColor = new Color(119, 168, 203, 0);
        //}
        //else
        //{
        //    camera.backgroundColor = new Color(100, 0, 0);
        //}

    }

    //private bool IsGrounded(){
    //    //return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1);
    //}
}
