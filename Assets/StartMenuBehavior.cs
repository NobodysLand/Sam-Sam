using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBehavior : MonoBehaviour
{
    public GameObject Canvas;
    private bool started = true;
    private AudioSource playSound;
    public GameObject video;
    public GameObject startMenu;

    private void Awake()
    {
        playSound = transform.Find("Sound play").GetComponent<AudioSource>();
    }

    private void Start()
    {
        //Canvas.transform.Find("Blackout").GetComponent<Animator>().SetTrigger("Blackin");
        StartCoroutine("EnableMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && started == false ) {
            started = true;
            playSound.Play();
            StartCoroutine("StartGame");
        }
    }

    IEnumerator StartGame ()
    {
        Canvas.transform.Find("Blackout").GetComponent<Animator>().SetTrigger("Blackout");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator EnableMenu()
    {
        Canvas.transform.Find("Blackout").GetComponent<Animator>().SetTrigger("Blackout");

        yield return new WaitForSeconds(45f);


        started = false;
        startMenu.SetActive(true);
        video.SetActive(false);
    }

}
