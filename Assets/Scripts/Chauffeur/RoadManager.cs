using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour {

    public GameObject EmplacementPanneau;

    public List<GameObject> ItemsSpawns;

    public GameObject myItem;

    public void ShowPannel(GameObject Pannel)
    {
        GameObject P = Instantiate(Pannel, EmplacementPanneau.transform.position, EmplacementPanneau.transform.rotation) as GameObject;
        P.transform.parent = this.gameObject.transform;
    }

    public void CreateItem(GameObject Item)
    {
        int randomPlace = Random.Range(0, ItemsSpawns.Count);

        GameObject I = Instantiate(Item, ItemsSpawns[randomPlace].transform.position, ItemsSpawns[randomPlace].transform.rotation) as GameObject;
        I.transform.parent = this.gameObject.transform;

        myItem = Item;
    }
}
