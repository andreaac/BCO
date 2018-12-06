using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {


	public bool playerInRange; 
	private GameObject player; 
	private MoveXYZ moveXYZ; 
	private PlayerScroller playerScroller; 
	private float startSpeed; 

	void Start () {
		moveXYZ = GetComponent<MoveXYZ>();
		playerScroller = GameObject.Find("Player").GetComponent<PlayerScroller>();
		startSpeed = moveXYZ.xyzSpeed.z;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(playerInRange)
		{
			player.transform.GetComponentInParent<PlayerScroller>().jaws.targetJaws(gameObject.transform);
			//print("show and move jaws");
		}
		if(playerScroller.boosting)
		{
			moveXYZ.xyzSpeed = new Vector3(moveXYZ.xyzSpeed.x, moveXYZ.xyzSpeed.y, -playerScroller.velocity);
		} else 
		{
			moveXYZ.xyzSpeed = new Vector3(moveXYZ.xyzSpeed.x, moveXYZ.xyzSpeed.y, startSpeed);
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "1 Bite Zone")
		{
			player = other.gameObject;
			player.transform.GetComponentInParent<PlayerScroller>().jaws.biteReady();
			playerInRange = true; 
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.name == "1 Bite Zone")
		{
			player.transform.GetComponentInParent<PlayerScroller>().jaws.noBite();
			playerInRange = false; 
		}
	}
}
