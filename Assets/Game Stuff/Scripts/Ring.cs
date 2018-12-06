using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {

	public PlayerScroller playerScroller; 
	private MoveXYZ mover;
	public float boostSpeed, originalMoveSpeed; 
	private bool shrinkIt; 

	void Start () {
		playerScroller = GameObject.Find("Player").GetComponent<PlayerScroller>();
		mover = GetComponent<MoveXYZ>();
		originalMoveSpeed = mover.xyzSpeed.z;
	}
	

	void Update () {
		if(playerScroller.boosting)
		{
			mover.xyzSpeed = new Vector3(0,0,boostSpeed);
		} else 
		{
			mover.xyzSpeed = new Vector3(0,0,originalMoveSpeed);
		}

		if(shrinkIt)
		{
			
			transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
			print("shrinking");
			if(transform.localScale.x >= 4.2f)
			{
				Destroy(this.gameObject);
			}
		}

	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			print("hello dolphin");
			//do collect anim 
			shrinkIt = true; 
		}
	}
}
