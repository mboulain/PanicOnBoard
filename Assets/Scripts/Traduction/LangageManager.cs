using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LangageManager : MonoBehaviour {

    public static LangageManager Instance;

    public bool English;

    public List<string> ActiveUi, UiFrançais, UiEnglish, ActiveDialoguesFixes, DialoguesFixesFrançais, DialoguesFixesEnglish, ActiveDialoguesRandom, DialoguesRandomFrançais, DialoguesRandomEnglish, ActiveTuto, TutoFrançais, TutoEnglish;

    public List<Sprite> ActiveUiImages, UiImagesFrançais, UiImagesEnglish, ActiveUiImagesRandom, UiImagesFrançaisRandom, UiImagesEnglishRandom;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
	
	// Update is called once per frame
	void Update () {

        DontDestroyOnLoad(this.gameObject);

	}

    public void ChooseEnglish()
    {
        English = true;

        for (int i = 0; i < ActiveUi.Count; i++)
        {
            ActiveUi[i] = UiEnglish[i];
        }
        for (int i = 0; i < ActiveDialoguesFixes.Count; i++)
        {
            ActiveDialoguesFixes[i] = DialoguesFixesEnglish[i];
        }
        for (int i = 0; i < ActiveDialoguesRandom.Count; i++)
        {
            ActiveDialoguesRandom[i] = DialoguesRandomEnglish[i];
        }
        for (int i = 0; i < ActiveTuto.Count; i++)
        {
            ActiveTuto[i] = TutoEnglish[i];
        }



        SceneManager.LoadScene(1);
    }

    public void ChooseFrançais()
    {
        English = false;

        for (int i = 0; i < ActiveUi.Count; i++)
        {
            ActiveUi[i] = UiFrançais[i];
        }
        for (int i = 0; i < ActiveDialoguesFixes.Count; i++)
        {
            ActiveDialoguesFixes[i] = DialoguesFixesFrançais[i];
        }
        for (int i = 0; i < ActiveDialoguesRandom.Count; i++)
        {
            ActiveDialoguesRandom[i] = DialoguesRandomFrançais[i];
        }
        for (int i = 0; i < ActiveTuto.Count; i++)
        {
            ActiveTuto[i] = TutoFrançais[i];
        }



        SceneManager.LoadScene(1);
    }
}
