using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusIntegrityManager : MonoBehaviour {

    public float StartingIntegrity;
    public float CurrentIntegrity;

    public static BusIntegrityManager BusHealth;

    private void Start()
    {
        CurrentIntegrity = StartingIntegrity;
        BusHealth = this;
    }

    public void LooseIntegrity(float damage)
    {
        CurrentIntegrity -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            LooseIntegrity(other.GetComponent<BusObstaclesScript>().BusDamage);
        }

        if (other.gameObject.tag == "RepairKit")
        {
            DriverInventoryManager.driverInventory.AddToInventory(other.gameObject, other.GetComponent<RepairKitScript>().myInventoryImage);
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        if (other.gameObject.tag == "BulletPack")
        {
            DriverInventoryManager.driverInventory.AddToInventory(other.gameObject, other.GetComponent<BulletPackScript>().myInventoryImage);
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
