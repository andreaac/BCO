using UnityEngine;
using System.Collections;

public class FishMaker : MonoBehaviour {

	public GameObject fishObj; 
	private float fishTimer, fishTime = 4.0f; 

	void Start () 
	{
	
	}
	

	void Update () 
	{
		fishTimer += Time.deltaTime;
		if(fishTimer >= fishTime)
		{
			fishTimer = 0.0f;
			GameObject instance = (GameObject)Instantiate(fishObj, transform.position + new Vector3(Random.Range(-2,2),Random.Range(-1.5f,1.5f),0), Quaternion.identity);
		}

	}
}
