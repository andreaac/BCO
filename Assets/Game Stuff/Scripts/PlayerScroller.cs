using UnityEngine;
using System.Collections;

public class PlayerScroller : MonoBehaviour {

	public UIJaws jaws; 
	public BiteZone biteZone; 
	public DolphinBoostStreams boostStreams; 
	public int velocity, playerSpeed = 1; 
	private Rigidbody playerRigid; 
	public float boostTime = 1.5f;
	private float yVelocity, xVelocity, boostTimer, spinTimer,spinTime = 1.0f, slashTimer, slashTime = 0.3f; 
	public bool boosting; 
	public bool slashing;
	private bool spinning;
	public ParticleSystem seaPartFast; 
	public Animator dolphinAnim; 
	public GameObject katanaTrail, slashTrail, katanaBubbles, wingTrails;
	private GameObject katana; 

	public bool eqKatana; 

	public float xMin,xMax,yMin,yMax;
	private int currentSlash;



	void Start () {
	
		playerRigid = GetComponent<Rigidbody>();
		katana = katanaTrail.transform.parent.gameObject;
		if(katana.activeInHierarchy)
		{
			eqKatana = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerMove();
		updateBoost(); 
		updateSpin();
		updateSlash();
		if (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.JoystickButton3))
		{
			if(!boosting)
			{
				boost();
			}
		}
		if (Input.GetKeyDown("x")|| Input.GetKeyDown(KeyCode.JoystickButton2))
		{
			spin();
			//print("spiny spiny");
		}
		if (Input.GetKeyDown("z")|| Input.GetKeyDown(KeyCode.JoystickButton1))
		{
			biteEat();
			slash();
		}
		if (Input.GetKeyDown("q")|| Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton5))
		{
			toggleSword();
		}
	}

	void playerMove()
	{
		yVelocity = Input.GetAxis("Vertical") * velocity; //vertical move speed set
		xVelocity = Input.GetAxis("Horizontal") * velocity; //horiz move speed set
		playerRigid.MovePosition(playerRigid.position + new Vector3(xVelocity,yVelocity,0) * Time.fixedDeltaTime); //
		if(transform.position.x <= xMin)
		{
			transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
		}
		if(transform.position.x >= xMax)
		{
			transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
		}
		if(transform.position.y <= yMin)
		{
			transform.position = new Vector3(transform.position.x,yMin, transform.position.z);
		}
		if(transform.position.y >= yMax)
		{
			transform.position = new Vector3(transform.position.x,yMax, transform.position.z);
		}
	}
	public void boost()
	{
		playerSpeed = 2;
		boostStreams.streamIt();
		boosting = true;
		//cooldown 
	}
	void updateBoost()
	{
		if(boosting)
		{
			
			boostTimer += Time.deltaTime;
			if(boostTimer >= boostTime)
			{
				boostTimer = 0.0f;
				boosting = false;
				playerSpeed = 1; 

			}
		}
	}


	public void spin()
	{
		if(!spinning)
		{
			dolphinAnim.SetTrigger("spin");
			if(!katana.activeInHierarchy)
			{
				wingTrails.SetActive(true);
			} else 
			{
				katanaTrail.SetActive(true);
			}

			spinning = true; 
		}
		currentSlash = 0;
		dolphinAnim.SetInteger("slash", currentSlash);

	}
	public void updateSpin()
	{
		if(spinning)
		{
			spinTimer += Time.deltaTime;
			if(spinTimer >= spinTime)
			{
				
				spinTimer = 0.0f;
				wingTrails.SetActive(false);
				katanaTrail.SetActive(false);
				spinning = false;
			}
		}
	}

	public void biteEat()
	{
		if(biteZone.foodInRange && !eqKatana)
		{
			if(biteZone.currentFood)
			{
				jaws.bite();
				Destroy(biteZone.currentFood);
				biteZone.eatReset();
				Camera.main.gameObject.GetComponent<screenShake>().shakeScreen(0.1f);
			}

		}

	}

	public void slash()
	{
		slashTrail.SetActive(true);
		if(currentSlash == 0)
		{
			currentSlash = 1;
		} else if (currentSlash == 1)
		{
			currentSlash = 2;
		} else if (currentSlash == 2)
		{
			currentSlash = 1;
		}
		dolphinAnim.SetInteger("slash", currentSlash);
		//print("slash");
		slashing = true; 
		slashTimer = 0.0f;
	}


	public void updateSlash() //cooldown to turn off slash particle renderer 
	{
		if(slashing)
		{
			slashTimer += Time.deltaTime;
			if(slashTimer >= slashTime)
			{
				slashTimer = 0.0f; 
				slashTrail.SetActive(false);
				slashing = false;
			}
		}
	}

	public void toggleSword()
	{
		
		katana.GetComponent<Katana>().resetBubbles();
		katanaBubbles.GetComponent<ParticleSystem>().Emit(30);
		//katana.GetComponent<Katana>().dropBubbles();
		eqKatana = !eqKatana;
		katana.SetActive(eqKatana);

	}

}
