using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslateText : MonoBehaviour {

    LangageManager langue;

    public string NomDeLaListe;
    public int NuméroDuMot;

    public bool RandomNumber;

    // Use this for initialization
    void Awake()
    {

        langue = FindObjectOfType<LangageManager>();

    }

    private void Start()
    {
        FillTheText(NomDeLaListe);
    }

    void FillTheText(string NameOfTheList)
    {
        if (!RandomNumber)
        {
            if (NameOfTheList == "ActiveUi")
            {
                GetComponent<Text>().text = langue.ActiveUi[NuméroDuMot];
            }
            if (NameOfTheList == "ActiveDialoguesFixes")
            {
                GetComponent<Text>().text = langue.ActiveDialoguesFixes[NuméroDuMot];
            }
            if (NameOfTheList == "ActiveDialoguesRandom")
            {
                GetComponent<Text>().text = langue.ActiveDialoguesRandom[NuméroDuMot];
            }
            if (NameOfTheList == "ActiveTuto")
            {
                GetComponent<Text>().text = langue.ActiveTuto[NuméroDuMot];
            }
        }

        if (RandomNumber)
        {
            if (NameOfTheList == "ActiveUi")
            {
                int rand = Random.Range(0, langue.ActiveUi.Count);
                GetComponent<Text>().text = langue.ActiveUi[rand];
            }
            if (NameOfTheList == "ActiveDialogues")
            {
                int rand = Random.Range(0, langue.ActiveDialoguesFixes.Count);
                GetComponent<Text>().text = langue.ActiveDialoguesFixes[rand];
            }
            if (NameOfTheList == "ActiveDialoguesRandom")
            {
                int rand = Random.Range(0, langue.ActiveDialoguesRandom.Count);
                GetComponent<Text>().text = langue.ActiveDialoguesRandom[rand];
                langue.ActiveDialoguesRandom.Remove(langue.ActiveDialoguesRandom[rand]);
            }
            if (NameOfTheList == "ActiveTuto")
            {
                int rand = Random.Range(0, langue.ActiveTuto.Count);
                GetComponent<Text>().text = langue.ActiveTuto[rand];
            }
        }
    }
}