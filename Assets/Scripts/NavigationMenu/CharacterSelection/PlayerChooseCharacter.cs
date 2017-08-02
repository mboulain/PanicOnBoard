using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChooseCharacter : MonoBehaviour {

    public GameObject P1Choice, P2Choice;
    ChooseCharacterScript choose;

    public string myRole;

    private void Start()
    {
        choose = FindObjectOfType<ChooseCharacterScript>();
    }


    // Update is called once per frame
    void Update () {

        if(choose.CurrentP1Choice == this.gameObject)
        {
            P1Choice.SetActive(true);

            if (Input.GetButtonDown("ControllerMenuAP1"))
            {
                choose.P1Locked = true;
            }
        }
        if (choose.CurrentP2Choice == this.gameObject)
        {
            P2Choice.SetActive(true);

            if (Input.GetButtonDown("ControllerMenuAP2"))
            {
                choose.P2Locked = true;
            }
        }

        if (choose.CurrentP1Choice != this.gameObject)
        {
            P1Choice.SetActive(false);
        }
        if (choose.CurrentP2Choice != this.gameObject)
        {
            P2Choice.SetActive(false);
        }


    }
}
