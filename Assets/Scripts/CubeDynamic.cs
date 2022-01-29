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
    private float shakeTimeRemaning, shakepower;

    public GameObject HeavenTiles;
    public GameObject HeavenBackground;

    public GameObject HellTiles;
    public GameObject HellBackground;

    public AudioSource ambienceSound;
    // Start is called before the first frame update
    void Start()
    {
        worldStatus = false;
        switchWorld = true;
    }

    // Update is called once per frame
    void Update()
    {

        isTouchingGround = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

        if (isTouchingGround && !switchWorld)
        {
            worldStatus = !worldStatus;
            switchWorld = true;
            //StartShake(0.1f, 1f);
        }

        if (worldStatus)
        {
            HeavenTiles.SetActive(true);
            HeavenBackground.SetActive(true);

            HellTiles.SetActive(false);
            HellBackground.SetActive(false);

            ambienceSound.pitch = 1.25f;
            player.GetComponent<Animator>().SetBool("Change", false);
        }
        else
        {
            HellTiles.SetActive(true);
            HellBackground.SetActive(true);

            HeavenTiles.SetActive(false);
            HeavenBackground.SetActive(false);

            ambienceSound.pitch = 1f;
            player.GetComponent<Animator>().SetBool("Change", true);
        }

    }

    //private void LateUpdate()
    //{
    //     if(shakeTimeRemaning > 0)
    //    {
    //        shakeTimeRemaning -= Time.deltaTime;

    //        float xAmount = Random.Range(-1f, 1f) * shakepower;
    //        float yAmount = Random.Range(-1f, 1f) * shakepower;
    //        camera.transform.position += new Vector3(xAmount, yAmount, 0f);
    //    }
    //}

    //public void StartShake(float length, float power)
    //{
    //    shakeTimeRemaning = length;
    //    shakepower = power;
    //}
}
