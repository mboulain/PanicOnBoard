using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPackScript : MonoBehaviour
{

    public float turnSpeed;

    public float NumberOfBullets;

    public Sprite myInventoryImage;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, turnSpeed, 0);

    }


}
