using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLangageInGame : MonoBehaviour
{

    MenuManager menu;
    PlayScript play;

    // Use this for initialization
    void Start()
    {
        menu = FindObjectOfType<MenuManager>();
        play = FindObjectOfType<PlayScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (menu.CurrentButton == this.gameObject)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("ControllerMenuAP1"))
            {
                play.ChangeLangage();
            }
        }

    }
}
