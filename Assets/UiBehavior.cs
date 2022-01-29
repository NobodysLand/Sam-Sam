using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiBehavior : MonoBehaviour
{
    public void ShowDeathText ()
    {
        transform.Find("Death").GetComponent<Animator>().SetTrigger("Fade in");
    }
}
