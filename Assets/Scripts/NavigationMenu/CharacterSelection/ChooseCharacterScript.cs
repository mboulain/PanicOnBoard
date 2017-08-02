using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseCharacterScript : MonoBehaviour {

    public GameObject CurrentP1Choice, CurrentP2Choice;

    public List<GameObject> Choices;

    public int P1int, P2int;

    public float timer1, timer2;

    public bool P1Locked, P2Locked;

    public Text StartText;

    bool gameStarted;

    InputSelectionScript SelectInputs;

	// Use this for initialization
	void Start () {

        P1int = 0;
        P2int = 1;
        CurrentP1Choice = Choices[0];
        CurrentP2Choice = Choices[1];
        StartText.enabled = false;

        SelectInputs = FindObjectOfType<InputSelectionScript>();
    }

    // Update is called once per frame
    void Update() {
        P1Choose();
        P2Choose();

        if (P1Locked)
        {
            if (Input.GetButtonDown("ControllerMenuBP1"))
            {
                P1Locked = false;
            }
        }

        if (P2Locked)
        {
            if (Input.GetButtonDown("ControllerMenuBP2"))
            {
                P2Locked = false;
            }
        }

        if(P1Locked && P2Locked)
        {
            StartText.enabled = true;

            if (Input.GetButtonDown("PressStart"))
            {
                if (!gameStarted)
                {
                    GiveInputs();
                }
            }
        }
        else
        {
            StartText.enabled = false;
        }
    }

    void P1Choose()
    {
        if (!P1Locked)
        {
            if (P1int == 0)
            {
                if (timer1 == 0)
                {
                    if (Input.GetAxisRaw("ChooseMenuP1") >= 0.8f)
                    {
                        P1int += 1;
                        CurrentP1Choice = Choices[P1int];
                        timer1 += Time.deltaTime;
                    }

                    if (Input.GetAxisRaw("ChooseMenuP1") <= -0.8f)
                    {
                        P1int += 1;
                        CurrentP1Choice = Choices[P1int];
                        timer1 += Time.deltaTime;
                    }
                }
            }
            if (P1int != 0)
            {
                if (timer1 == 0)
                {
                    if (Input.GetAxisRaw("ChooseMenuP1") >= 0.8f)
                    {
                        P1int = 0;
                        CurrentP1Choice = Choices[P1int];
                        timer1 += Time.deltaTime;
                    }
                    if (Input.GetAxisRaw("ChooseMenuP1") <= -0.8f)
                    {
                        P1int -= 1;
                        CurrentP1Choice = Choices[P1int];
                        timer1 += Time.deltaTime;
                    }
                }
            }


            if (Input.GetAxisRaw("ChooseMenuP1") == 0 || timer1 >= 0.5f)
            {
                timer1 = 0;
            }
        }
    }

    void P2Choose()
    {
        if (!P2Locked)
        {
            if (P2int == 0)
            {
                if (timer2 == 0)
                {
                    if (Input.GetAxisRaw("ChooseMenuP2") >= 0.8f)
                    {
                        P2int += 1;
                        CurrentP2Choice = Choices[P2int];
                        timer2 += Time.deltaTime;
                    }

                    if (Input.GetAxisRaw("ChooseMenuP2") <= -0.8f)
                    {
                        P2int += 1;
                        CurrentP2Choice = Choices[P2int];
                        timer2 += Time.deltaTime;
                    }
                }
            }
            if (P2int != 0)
            {
                if (timer2 == 0)
                {
                    if (Input.GetAxisRaw("ChooseMenuP2") >= 0.8f)
                    {
                        P2int = 0;
                        CurrentP2Choice = Choices[P2int];
                        timer2 += Time.deltaTime;
                    }
                    if (Input.GetAxisRaw("ChooseMenuP2") <= -0.8f)
                    {
                        P2int -= 1;
                        CurrentP2Choice = Choices[P2int];
                        timer2 += Time.deltaTime;
                    }
                }
            }


            if (Input.GetAxisRaw("ChooseMenuP2") == 0 || timer2 >= 0.5f)
            {
                timer2 = 0;
            }
        }
    }


    public void GiveInputs()
    {
        gameStarted = true;

        if (CurrentP1Choice.GetComponent<PlayerChooseCharacter>().myRole == "MineSweeper")
        {
            SelectInputs.Player1isCop();
        }
        if (CurrentP1Choice.GetComponent<PlayerChooseCharacter>().myRole == "BusDriver")
        {
            SelectInputs.Player1isDriver();
        }

        if (CurrentP2Choice.GetComponent<PlayerChooseCharacter>().myRole == "MineSweeper")
        {
            SelectInputs.Player2isCop();
        }
        if (CurrentP2Choice.GetComponent<PlayerChooseCharacter>().myRole == "BusDriver")
        {
            SelectInputs.Player2isDriver();
        }

        if (CurrentP1Choice == CurrentP2Choice)
        {
            SelectInputs.RandomInputs();
        }

        SceneManager.LoadScene(3);
    }
}
