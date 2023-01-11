using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : MonoBehaviour
{

    private float distanceNear;

    public GameObject[] dialogue;

    public GameObject player;
    public GameObject[] menu; // Assign in inspector
    private bool isShowing;

    void Update()
    {

        {
            for (int i = 0; i < menu.Length; i++)
            {
                distanceNear = Vector3.Distance(menu[i].transform.position, player.transform.position);

                if (distanceNear < 3)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {

                        isShowing = !isShowing;
                        dialogue[i].SetActive(isShowing);

                    }
                }
            }



        }
    }
}
