using UnityEngine;
using System.Collections;

public class RotateXYZ : MonoBehaviour {

	public Vector3 speed;

	void Start () {
	
	}
	

	void Update () 
	{
		transform.Rotate(new Vector3(speed.x * Time.deltaTime, speed.y * Time.deltaTime, speed.z * Time.deltaTime));
	}
}
