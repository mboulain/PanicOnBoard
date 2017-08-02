using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatformController : MonoBehaviour {

    GameObject DestructionPoint;
    RunnerControllerScript run;

	// Use this for initialization
	void Start () {

        DestructionPoint = GameObject.Find("DestructionPoint");
        run = FindObjectOfType<RunnerControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {	
        	
        if(transform.position.z < DestructionPoint.transform.position.z)
        {
            run.GeneratePlatforms();
            run.HidePlatform(transform.parent.gameObject);
        }
	}
}
