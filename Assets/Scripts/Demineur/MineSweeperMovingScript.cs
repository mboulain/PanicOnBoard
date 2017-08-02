using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSweeperMovingScript : MonoBehaviour {

    public float MoveSpeed;

    InputSelectionScript allinputs;
    CharacterController CC;
    public bool isTargetting;

	// Use this for initialization
	void Start () {
        allinputs = FindObjectOfType<InputSelectionScript>();
        CC = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        CC.SimpleMove(Physics.gravity);

        Vector3 movement = new Vector3(Input.GetAxis(allinputs.ActivesCopInputs[0]), 0, Input.GetAxis(allinputs.ActivesCopInputs[1])) * MoveSpeed;

        CC.Move(movement * Time.deltaTime);

        Vector3 LookPos = new Vector3(Input.GetAxis(allinputs.ActivesCopInputs[0]), 0, Input.GetAxis(allinputs.ActivesCopInputs[1]));

        if (LookPos != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(LookPos);
        }

    }
}
