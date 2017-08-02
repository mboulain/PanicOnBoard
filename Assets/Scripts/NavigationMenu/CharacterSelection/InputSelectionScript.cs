using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSelectionScript : MonoBehaviour {

    public static InputSelectionScript Instance;

    public List<string> ActivesCopInputs, ActiveDriverInputs, CopInputs, DriverInputs;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    public void Player1isCop()
    {
        for (int i = 0; i < CopInputs.Count; i++)
        {
            ActivesCopInputs[i] = CopInputs[i] + "P1";
        }
    }

    public void Player1isDriver()
    {
        for (int i = 0; i < DriverInputs.Count; i++)
        {
            ActiveDriverInputs[i] = DriverInputs[i] + "P1";
        }
    }

    public void Player2isCop()
    {
        for (int i = 0; i < CopInputs.Count; i++)
        {
            ActivesCopInputs[i] = CopInputs[i] + "P2";
        }
    }

    public void Player2isDriver()
    {
        for (int i = 0; i < DriverInputs.Count; i++)
        {
            ActiveDriverInputs[i] = DriverInputs[i] + "P2";
        }
    }


    public void RandomInputs()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            Player1isCop();
            Player2isDriver();
        }

        if(rand == 1)
        {
            Player1isDriver();
            Player2isCop();
        }

    }

}
