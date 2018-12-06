using UnityEngine;
using System.Collections;

public class Katana : MonoBehaviour {

	public GameObject katanaBubbles; 
	public Vector3 katanaBubbleStart; 
	public bool attacking; 

	void Start () 
	{
		katanaBubbleStart = katanaBubbles.transform.localPosition;
	}



	void Update () 
	{
	
	}


	public void dropBubbles()
	{
		katanaBubbles.transform.parent = null; 
	}
	public void resetBubbles()
	{
		katanaBubbles.transform.parent = transform; //reattach bubbles to this game object, the katana
		katanaBubbles.transform.localPosition = katanaBubbleStart;
		//print(katanaBubbles.transform.parent.name);
		//print(katanaBubbles.transform.localPosition);
		dropBubbles();
	}
}
