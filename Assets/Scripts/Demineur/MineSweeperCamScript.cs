using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSweeperCamScript : MonoBehaviour {

    MineSweeperMovingScript theCop;
    float PosZ, StartingDifZ;

	// Use this for initialization
	void Start () {
        theCop = FindObjectOfType<MineSweeperMovingScript>();
        StartingDifZ = transform.position.z - theCop.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

        PosZ = theCop.transform.position.z + StartingDifZ;

        this.transform.position = new Vector3(theCop.transform.position.x, transform.position.y, PosZ);
	}
}
