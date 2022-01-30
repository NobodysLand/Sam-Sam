using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBehavior : MonoBehaviour
{
    public GameObject Canvas;

    private void Start()
    {
        Canvas.transform.Find("Blackout").GetComponent<Animator>().SetTrigger("Blackin");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine("StartGame");
            
        }
    }

    IEnumerator StartGame ()
    {
        Canvas.transform.Find("Blackout").GetComponent<Animator>().SetTrigger("Blackout");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
