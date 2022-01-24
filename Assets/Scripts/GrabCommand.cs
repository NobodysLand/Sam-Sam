using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCommand : MonoBehaviour
{

    public Transform grabDetect;
    public Transform boxHolder;
    public Transform box;
    public float rayDist;

    public bool grabbing = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (Input.GetKeyDown("space"))
            {
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbing = true;
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.black;
                box.gameObject.transform.parent = null;
                box.GetComponent<Rigidbody2D>().isKinematic = false;
            }

        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            if (Input.GetKeyDown("space") && grabbing == true)
            {
                grabbing = false;
                box.transform.parent = null;
                box.GetComponent<Rigidbody2D>().isKinematic = false;
                if (GetComponent<SpriteRenderer>().flipX == true)
                {
                    box.GetComponent<Rigidbody2D>().velocity = new Vector3(5f, 5f, 0);
                }
                if (GetComponent<SpriteRenderer>().flipX == false)
                {
                    box.GetComponent<Rigidbody2D>().velocity = new Vector3(-5f, 5f, 0);
                }
            }
        }

    }
}
