using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidsBehavior : MonoBehaviour
{
    GameObject ui;

    private void Awake()
    {
        ui = GameObject.FindGameObjectWithTag("Ui");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterMovement>().Drown();
            ui.GetComponent<UiBehavior>().ShowDeathText();
        }
    }
}
