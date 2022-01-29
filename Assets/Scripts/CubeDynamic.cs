using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDynamic : MonoBehaviour
{

    public GameObject player;
    public bool worldStatus;
    public new GameObject camera;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    public bool switchWorld;

    public GameObject HeavenTiles;
    public GameObject HeavenBackground;

    public GameObject HellTiles;
    public GameObject HellBackground;

    public AudioSource ambienceSound;
    private AudioSource cubeSound;

    void Awake()
    {
        switchWorld = true;
        player = GameObject.FindGameObjectWithTag("Player");
        cubeSound = gameObject.GetComponent<AudioSource>();
        camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        isTouchingGround = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

        if (isTouchingGround && !switchWorld)
        {
            worldStatus = !worldStatus;
            switchWorld = true;
            cubeSound.Play();
            camera.GetComponent<CameraMovement>().Shake();
            
        }
        if (!isTouchingGround)
        {
            switchWorld = false;
        }
        

        if (worldStatus)
        {
            HeavenTiles.SetActive(true);
            HeavenBackground.SetActive(true);

            HellTiles.SetActive(false);
            HellBackground.SetActive(false);

            ambienceSound.pitch = 1.25f;
            player.GetComponent<Animator>().SetBool("Change", false);

            camera.GetComponent<Camera>().backgroundColor = new Color(117, 197, 255, 0);
            
        }
        else
        {
            HellTiles.SetActive(true);
            HellBackground.SetActive(true);

            HeavenTiles.SetActive(false);
            HeavenBackground.SetActive(false);

            ambienceSound.pitch = 1f;
            player.GetComponent<Animator>().SetBool("Change", true);

            camera.GetComponent<Camera>().backgroundColor = new Color(39, 0, 2, 0);
        }

    }


}
