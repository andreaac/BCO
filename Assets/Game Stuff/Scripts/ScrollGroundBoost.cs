using UnityEngine;
using System.Collections;

public class ScrollGroundBoost : MonoBehaviour {

	public PlayerScroller playerScroller; 
	public ScrollGround scrollGround; 

	private float scrollYStart; 
	public float boostSpeed; 

	void Start () {
		scrollYStart = scrollGround.scrollSpeedy; 
	}
	

	void Update () 
	{
		if(playerScroller.boosting)
		{
			//scrollGround.scrollSpeedy = boostSpeed; 
		} else 
		{
			//scrollGround.scrollSpeedy = scrollYStart;
		}
	}


}
