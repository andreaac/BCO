using UnityEngine;
using System.Collections;

public class SeaParticles : MonoBehaviour {

	public PlayerScroller playerScroller;
	public ParticleSystem seaPartReg,seaPartFast; 

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(playerScroller.boosting)
		{
			seaPartFast.gameObject.SetActive(true);
			seaPartReg.gameObject.SetActive(false);
		} else 
		{
			seaPartFast.gameObject.SetActive(false);
			seaPartReg.gameObject.SetActive(true);
		}
	}
}
