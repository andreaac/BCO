using UnityEngine;
using System.Collections;

public class UIJaws : MonoBehaviour {

	public GameObject jawsOpen, jawsClose; 
	public bool eaten; 
	private float eatTimer, eatTime = 1.0f; 

	void Start () 
	{
	
	}
	

	void Update () 
	{
		if(eaten)
		{
			eatTimer += Time.deltaTime;
			if(eatTimer >= eatTime)
			{
				jawsClose.transform.parent = this.gameObject.transform;
				jawsClose.transform.localPosition = new Vector3(0,0,0);
				eatTimer = 0.0f;
				eaten = false;
			}
		}
	}


	public void bite()
	{
			eaten = true; //disable on a short timer for the next one 
			jawsOpen.SetActive(false);
			jawsClose.SetActive(true); 
			jawsClose.GetComponent<Animator>().SetTrigger("bite");
			jawsClose.transform.parent = null;


	}
	public void biteReady()
	{
		if(!eaten && !gameObject.transform.GetComponentInParent<PlayerScroller>().eqKatana)
		{
			jawsOpen.SetActive(true);
			jawsClose.SetActive(false);
		}
	}
	public void noBite()
	{
		jawsOpen.SetActive(false);
		jawsClose.SetActive(false);
		eaten = false;
	}


	public void targetJaws(Transform target)
	{
		transform.position = new Vector3(target.position.x, target.position.y, target.position.z - 0.1f);
	}


}
