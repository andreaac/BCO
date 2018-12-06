using UnityEngine;
using System.Collections;

public class ScrollerGenericMove : MonoBehaviour {

	public PlayerScroller playerScroller; 
	private MoveXYZ moveXYZ; 
	private float startSpeed; 

	void Start () {
		moveXYZ = GetComponent<MoveXYZ>();
		playerScroller = GameObject.Find("Player").GetComponent<PlayerScroller>();
		startSpeed = moveXYZ.xyzSpeed.z;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(playerScroller.boosting)
		{
			moveXYZ.xyzSpeed = new Vector3(moveXYZ.xyzSpeed.x, moveXYZ.xyzSpeed.y, -playerScroller.velocity);
		} else 
		{
			moveXYZ.xyzSpeed = new Vector3(moveXYZ.xyzSpeed.x, moveXYZ.xyzSpeed.y, startSpeed);
		}
	}
}
