using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDynamic : MonoBehaviour
{

    public GameObject player;
    public bool worldStatus;
    public Transform groundDetect;

    // Start is called before the first frame update
    void Start()
    {
        worldStatus = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, transform.localScale, 0);

        if (groundCheck.collider != null && groundCheck.collider.tag == "Ground")
        {
            //worldStatus = !worldStatus;
        }


    }
}
