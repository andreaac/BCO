using UnityEngine;
using System.Collections;

public class Catcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.layer == 8)
		{
			Destroy(other.gameObject);
		}
	}
}
