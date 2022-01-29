using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportController : MonoBehaviour
{
    private GameObject player;
    private Collider2D collider;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Transform check = collision.transform.Find("Cube Holder").Find("Cube");
            if (check != null)
            {
                Debug.Log("Tá co cubo miseravis kkkkkk");
                Debug.Log(SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
    }
}
