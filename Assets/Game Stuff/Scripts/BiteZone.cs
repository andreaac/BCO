using UnityEngine;
using System.Collections;

public class BiteZone : MonoBehaviour {


	public bool foodInRange; 
	public GameObject currentFood; 

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "edible")
		{
			foodInRange = true; 
			currentFood = other.gameObject; 
		}

			
	}

	public void eatReset()
	{
		foodInRange = false; 

	}
	public void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "edible")
		{
			foodInRange = false; 
			currentFood = null;
		}
	}
}
