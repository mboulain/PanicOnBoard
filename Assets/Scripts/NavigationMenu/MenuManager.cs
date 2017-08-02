using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject CurrentButton;

    public List<GameObject> AllButtons;
    public int CurrentInt;

    public float timer;

    private void Start()
    {
        timer = 0;
        CurrentButton = AllButtons[0].gameObject;
        AllButtons[0].GetComponent<HighLightScript>().OnMouseOver();
    }

    // Update is called once per frame
    void Update () {

        if (CurrentInt == 0)
        {
            if (timer == 0)
            {
                if (Input.GetAxisRaw("MovePilotVerticalP1") >= 0.8f)
                {
                    CurrentInt = AllButtons.Count - 1;
                    CurrentButton = AllButtons[CurrentInt];
                    timer += Time.deltaTime;
                }
            }
        }
        if (CurrentInt > 0)
        {
            if (timer == 0)
            {
                if (Input.GetAxisRaw("MovePilotVerticalP1") >= 0.8f)
                {
                    CurrentInt -= 1;
                    CurrentButton = AllButtons[CurrentInt];
                    timer += Time.deltaTime;
                }
            }
        }
        if (CurrentInt < AllButtons.Count - 1)
        {
            if (timer == 0)
            {
                if (Input.GetAxisRaw("MovePilotVerticalP1") <= -0.8f)
                {
                    CurrentInt += 1;
                    CurrentButton = AllButtons[CurrentInt];
                    timer += Time.deltaTime;
                }
            }
        }
        if (CurrentInt == AllButtons.Count - 1)
        {
            if (timer == 0)
            {
                if (Input.GetAxisRaw("MovePilotVerticalP1") <= -0.8f)
                {
                    CurrentInt = 0;
                    CurrentButton = AllButtons[CurrentInt];
                    timer += Time.deltaTime;
                }
            }
        }


        if (Input.GetAxisRaw("MovePilotVerticalP1") == 0 || timer >= 0.5f)
        {
            timer = 0;
        }
    }
}
