using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslateImage : MonoBehaviour
{

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
        ChangePicture(NomDeLaListe);
    }

    void ChangePicture(string NameOfTheList)
    {
        if (!RandomNumber)
        {
            if (NameOfTheList == "ActiveUiImages")
            {
                GetComponent<Image>().sprite = langue.ActiveUiImages[NuméroDuMot];
            }

        }

        if (RandomNumber)
        {
            if (NameOfTheList == "ActiveDialoguesRandom")
            {
                int rand = Random.Range(0, langue.ActiveUiImagesRandom.Count);
                GetComponent<Image>().sprite = langue.ActiveUiImagesRandom[rand];
                langue.ActiveUiImagesRandom.Remove(langue.ActiveUiImagesRandom[rand]);
            }
        }
    }
}
