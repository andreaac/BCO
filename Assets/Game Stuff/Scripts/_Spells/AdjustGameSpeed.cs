using UnityEngine;
using System.Collections;

public class AdjustGameSpeed : MonoBehaviour {


	public float fastSpeed; 
	public float regularSpeed;
	public float slowSpeed; 
	public bool available = false; 

	void Start () {
	
	}
	

	void Update () 
	{
		if(available)
		{
			if (Input.GetKeyDown("l"))
			{
				Time.timeScale = fastSpeed;
			}
			if(Input.GetKeyDown("k"))
			{
				Time.timeScale = regularSpeed;
			}
			if(Input.GetKeyDown("j"))
			{
				Time.timeScale = slowSpeed;
			}

		}
		
	}
}
