using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialoguemanager : MonoBehaviour
{
    public GameObject menu; // Assign in inspector
    private bool isShowing;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }
    }
}
