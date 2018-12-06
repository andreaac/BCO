using UnityEngine;
using System.Collections;

public class HumanScroller : MonoBehaviour {

	public GameObject head,body,arm1,arm2,leg1,leg2; 
	public ParticleSystem bloodHead; 
	void Start () {
	
	}
	

	void Update () {
		if (Input.GetButtonDown ("Fire2"))
		{
			//decapitate();
		}
	}

	public void decapitate()
	{
		head.GetComponent<Rigidbody>().isKinematic = false;
		head.GetComponent<Rigidbody>().AddForce(20,25,0,ForceMode.Impulse);
		head.GetComponent<Rigidbody>().AddTorque(25,5,0,ForceMode.Impulse);
		bloodHead.Play();
		Camera.main.GetComponent<screenShake>().shakeScreen(0.1f);


	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "weapon")
		{
			if(other.gameObject.name == "katana") 
			{
				if(other.gameObject.transform.parent.transform.parent.GetComponent<PlayerScroller>().slashing)
				{
					decapitate();
				}

			}

		}
	}
}
