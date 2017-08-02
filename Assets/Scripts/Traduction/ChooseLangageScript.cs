using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLangageScript : MonoBehaviour {

    MenuManager menu;
    LangageManager langues;

    public string myLangage;

	// Use this for initialization
	void Start () {
        menu = FindObjectOfType<MenuManager>();
        langues = FindObjectOfType<LangageManager>();		
	}
	
	// Update is called once per frame
	void Update () {

        if(menu.CurrentButton == this.gameObject)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("ControllerMenuAP1"))
            {
                if (myLangage == "Français")
                {
                    langues.ChooseFrançais();
                }
                if (myLangage == "English")
                {
                    langues.ChooseEnglish();
                }
            }
        }
		
	}
}
