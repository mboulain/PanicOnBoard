using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerControllerScript : MonoBehaviour {

    public List<GameObject> ActivesPlatforms, AllPlatforms;
    public GameObject LastPlatformCreated;

    public List<GameObject> GoodPannels, FakePannels;

    public List<GameObject> AllItems;

    public int IntBeforePannel, MinInt, MaxInt;
    public int LuckTrue, LuckFalse;
    int PannelIndic;

    public int IntBeforeItem;
    int itemint;

    public static RunnerControllerScript theRunnerManager;

	// Use this for initialization
	void Start () {

        LastPlatformCreated = ActivesPlatforms[ActivesPlatforms.Count - 1];
        IntBeforePannel = Random.Range(MinInt, MaxInt);
        theRunnerManager = this;
	}

    public void GeneratePlatforms()
    {
        //Le texte du dessous représente l'object Pooling

        /*for (int i = 0; i < ActivesPlatforms.Count; i++)
        {
            if (!ActivesPlatforms[i].activeInHierarchy)
            {
                ActivesPlatforms[i].SetActive(true);
                ActivesPlatforms[i].transform.position = LastPlatformCreated.GetComponentInChildren<DestroyPlatformController>().transform.position;
                LastPlatformCreated = ActivesPlatforms[i];
                return;
            }
        }*/

        // Pour une génération de plateformes aléatoires, exécuter le code ci-dessous
        int rand = Random.Range(0, AllPlatforms.Count);
        GameObject P = Instantiate(AllPlatforms[rand], LastPlatformCreated.GetComponentInChildren<DestroyPlatformController>().transform.position, transform.rotation) as GameObject;
        ActivesPlatforms.Add(P.gameObject);
        LastPlatformCreated = P;

        PannelIndic += 1;
        itemint += 1;

        if(PannelIndic == IntBeforePannel)
        {
            int luck = Random.Range(0, LuckTrue + LuckFalse + 1);

            if(luck <= LuckTrue)
            {
                P.GetComponent<RoadManager>().ShowPannel(GoodPannels[0]);

                GoodPannels.Remove(GoodPannels[0]);
                IntBeforePannel = Random.Range(MinInt, MaxInt);

                PannelIndic = 0;
            }

            if(luck > LuckTrue)
            {
                int randomFake = Random.Range(0, FakePannels.Count);

                P.GetComponent<RoadManager>().ShowPannel(FakePannels[randomFake]);
                IntBeforePannel = Random.Range(MinInt, MaxInt);

                PannelIndic = 0;
            }
        }

        if(itemint >= IntBeforeItem)
        {
            int randomitem = Random.Range(0, AllItems.Count);

            P.GetComponent<RoadManager>().CreateItem(AllItems[randomitem]);

            itemint = 0;
        }
    }

    public void HidePlatform(GameObject Platform)
    {
        Platform.SetActive(false);
    }
}
