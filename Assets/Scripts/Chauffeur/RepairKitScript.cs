using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairKitScript : MonoBehaviour {

    public float turnSpeed;

    public float RepairAmount;

    public Sprite myInventoryImage;
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0, turnSpeed, 0);
		
	}

    public void RepairBus()
    {
        BusIntegrityManager.BusHealth.CurrentIntegrity += RepairAmount;
    }
}
