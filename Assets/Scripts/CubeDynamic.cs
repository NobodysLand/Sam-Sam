using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDynamic : MonoBehaviour
{

    public GameObject player;
    public bool worldStatus;
    public Transform groundDetect;
    private float distToGround;
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
        //RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down);

        //if (groundCheck.collider != null && groundCheck.collider.tag == "Ground")
        //{
        //    worldStatus = !worldStatus;
        //}

        Ray FootRay;
        RaycastHit hit;
        FootRay = new Ray(gameObject.transform.position, Vector3.down);
        //Debug.Log(FootRay);
        //if (FootRay) { 
        //    worldStatus = Physics.Raycast(FootRay, out hit, 1.0f);
        //}

    }

    //private bool IsGrounded(){
    //    //return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1);
    //}
}
