using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
