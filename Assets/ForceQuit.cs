using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceQuit : MonoBehaviour
{
    private void OnEnable()
    {
        Application.Quit();
    }
}
