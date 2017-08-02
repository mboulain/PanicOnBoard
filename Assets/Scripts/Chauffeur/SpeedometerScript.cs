using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedometerScript : MonoBehaviour {

    public static float MinAngle = 180;
    public static float MaxAngle = 0;

    static SpeedometerScript speedo;

	// Use this for initialization
	void Start () {
        speedo = this;
	}
	
	public static void ShowSpeed(float speed, float min, float max)
    {
        float ang = Mathf.Lerp(MinAngle, MaxAngle, Mathf.InverseLerp(min, max, speed));
        speedo.transform.eulerAngles = new Vector3(0, 0, ang);
    }
}
