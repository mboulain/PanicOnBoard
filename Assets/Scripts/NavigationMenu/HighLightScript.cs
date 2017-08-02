using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighLightScript : MonoBehaviour {

    MenuManager menu;

    public Color OffColor, OnColor;

    public int myInt;

    public bool isSelected;

    private void Awake()
    {
        menu = FindObjectOfType<MenuManager>();
    }

    private void Start()
    {
        for (int i = 0; i < menu.AllButtons.Count; i++)
        {
            if (menu.AllButtons[i] == this.gameObject)
            {
                myInt = i;
            }
        }
    }

    private void Update()
    {
        if (menu.CurrentButton == this.gameObject)
        {
            isSelected = true;
        }
        if (menu.CurrentButton != this.gameObject)
        {
            isSelected = false;
        }

        if (isSelected)
        {
            GetComponent<Text>().color = OnColor;
        }

        if (!isSelected)
        {
            GetComponent<Text>().color = OffColor;
        }
    }

    public void OnMouseOver()
    {
        GetComponent<Text>().color = OnColor;
        menu.CurrentInt = myInt;
        menu.CurrentButton = this.gameObject;
        
    }

    public void OnMouseExit()
    {
        GetComponent<Text>().color = OffColor;
        menu.CurrentInt = 0;
        menu.CurrentButton = null;
    }
}
