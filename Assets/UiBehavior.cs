using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiBehavior : MonoBehaviour
{
    public Animator blackImg;
    public Animator text;

    private void Awake()
    {
        blackImg = transform.Find("Blackout").GetComponent<Animator>();
        text = transform.Find("Death").GetComponent<Animator>();

    }
    public void ShowDeathText ()
    {
        blackImg.SetTrigger("Blackout");
        text.SetTrigger("Fade in");
    }

    public void Blackin ()
    {
        blackImg.SetTrigger("Blackin");
    }
}
