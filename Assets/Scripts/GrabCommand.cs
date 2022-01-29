using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCommand : MonoBehaviour
{

    public Transform grabDetect;
    public Transform boxHolder;
    public Transform box;
    public float rayDist;
    public GameObject grabIcon;

    public bool grabbing = false;

    public Animator animator;


    public GameObject cube;
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.zero * transform.localScale, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (Input.GetKeyDown("space"))
            {
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezeRotationZ;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                grabbing = true;
                grabCheck.collider.gameObject.SetActive(false);
                animator.SetBool("Grab", true);
                cube.GetComponent<CubeDynamic>().switchWorld = false;
            }
            else
            {
                grabIcon.SetActive(true);
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().constraints = new RigidbodyConstraints2D();
            }

        }
        else
        {
            grabIcon.SetActive(false);
            if (Input.GetKeyDown("space") && grabbing == true)
            {
                box.GetComponent<Rigidbody2D>().simulated = true;
                grabbing = false;
                animator.SetBool("Grab", false);
                box.gameObject.SetActive(true);
                box.transform.parent = null;
                box.GetComponent<Rigidbody2D>().isKinematic = false;
                if (GetComponent<SpriteRenderer>().flipX == true)
                {
                    box.GetComponent<Rigidbody2D>().velocity = new Vector3(15f, 15f, 0);
                }
                if (GetComponent<SpriteRenderer>().flipX == false)
                {
                    box.GetComponent<Rigidbody2D>().velocity = new Vector3(-15f, 15f, 0);
                }
            }
        }

    }
}
