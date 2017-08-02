using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrivingScript : MonoBehaviour {

    public float Movespeed, turnSpeed, MaxSpeed;
    Rigidbody rb;
    InputSelectionScript allinputs;
    float move;

    public Text SpeedText;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        allinputs = FindObjectOfType<InputSelectionScript>();
        rb.AddForce(new Vector3(move, rb.velocity.y, Movespeed));

    }

    // Update is called once per frame
    void Update () {

        if (!DriverInventoryManager.driverInventory.InventoryOpened)
        {
            move = Input.GetAxis(allinputs.ActiveDriverInputs[0]) * turnSpeed;
        }
            rb.AddForce(new Vector3(move, rb.velocity.y, Movespeed));
        

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);

        SpeedText.text = Mathf.Round(rb.velocity.magnitude).ToString() + " Km/h";

        // Permet de convertir la vitesse sur le cadran (100 étant la dernière valeur affichée sur le cadran)
        SpeedometerScript.ShowSpeed(rb.velocity.magnitude, 0, 100);

    }

    public void LooseSpeed(float value)
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, (rb.velocity.z - ((rb.velocity.z * value) / 100)));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            LooseSpeed(other.GetComponent<BusObstaclesScript>().SpeedDamagePercent);
        }

        if(other.gameObject.tag == "RepairKit")
        {
            
        }
    }
}
