using UnityEngine;
using System.Collections;

public class ScrollerLevel : MonoBehaviour {

	public Transform ringSpot, collumnSpot, spawnSpot; 
	public GameObject ring, column, columnBroken, kelp;

	private float ringTimer,ringTime = 2.0f, collumnTimer, columnTime = 4.0f, makeColTimer, kelpTimer, kelpTime = 1.0f; 

	public bool makingColumns, makingKelp; 

	public float makeColTime;  //time until we make some collumns, then after a while, turn off. 
	private Vector3 randomKelpSpot; 

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		makeColTimer += Time.deltaTime; 
		if(makeColTimer >= makeColTime && makeColTimer <= makeColTime + 21.0f) //limited window -- for now -- to make collumns 
		{
			makingColumns = true;
		} else 
		{
			makingColumns = false; 
		}

	
		if (Input.GetKeyDown("space"))
		{
			//makeRing();
			//makeCollumn1();
		}
		ringTimer += Time.deltaTime;
		if(ringTimer >= ringTime)
		{
			ringTimer = 0.0f;
			makeRing();
		}
		if(makingColumns)
		{
			collumnTimer += Time.deltaTime; 
			if(collumnTimer >= columnTime)
			{
				collumnTimer = 0.0f; 
				makeCollumn1();
			}
		}
		if(makingKelp)
		{
			kelpTimer += Time.deltaTime;
			if(kelpTimer >= kelpTime)
			{
				kelpTimer = 0.0f;  
				makeKelp();
			}
		}

	}

	void makeRing()
	{
		GameObject instance = (GameObject)Instantiate(ring,ringSpot.position,Quaternion.identity);
	}

	void makeCollumn1()
	{
		float randomCol = Random.Range(0.0f,1.0f);
		if(randomCol >= 0.5f)
		{
			GameObject instance = (GameObject)Instantiate(column,collumnSpot.position,Quaternion.identity);
		} else 
		{
			GameObject instance = (GameObject)Instantiate(columnBroken,collumnSpot.position,Quaternion.identity);
		}

	}

	void makeKelp()
	{
		randomKelpSpot = spawnSpot.position + new Vector3(Random.Range(-5,5),0,Random.Range(-5,5));
		GameObject instance = (GameObject)Instantiate(kelp,randomKelpSpot,Quaternion.identity); 
		instance.transform.GetChild(0).transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);

	}



}
