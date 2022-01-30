using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiBehavior : MonoBehaviour
{
    public void ShowDeathText ()
    {
        transform.Find("Death").GetComponent<Animator>().SetTrigger("Fade in");
        transform.Find("Blackout").GetComponent<Animator>().SetTrigger("Blackout");
    }
}
