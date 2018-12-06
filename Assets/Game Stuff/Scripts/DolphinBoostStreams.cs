using UnityEngine;
using System.Collections;

public class DolphinBoostStreams : MonoBehaviour {

	public PlayerScroller playerScroller; 
	public GameObject stream1, stream2;
	private int streamState; 
	private float streamTime, streamTimer, leaveTime = 1.0f;
	private Vector3 streamStart1,streamStart2; 


	void Start () 
	{
		streamTime = playerScroller.boostTime;
		streamStart1 = stream1.transform.localPosition;
		streamStart2 = stream2.transform.localPosition;
	}
	

	void Update () 
	{
		if(streamState == 0)
		{
			stream1.transform.localScale = new Vector3(stream1.transform.localScale.x, 0, stream1.transform.localScale.z);
			stream2.transform.localScale = new Vector3(stream2.transform.localScale.x, 0, stream2.transform.localScale.z);
			stream1.transform.parent = this.gameObject.transform;
			stream2.transform.parent = this.gameObject.transform;
		} else if(streamState == 1)
		{
			stream1.transform.localPosition = streamStart1;
			stream2.transform.localPosition = streamStart2;
			stream1.transform.localScale += new Vector3(0, 0.1f * Time.deltaTime,0);
			stream2.transform.localScale += new Vector3(0, 0.1f * Time.deltaTime,0);
			streamTimer += Time.deltaTime;
			if(streamTimer >= streamTime)
			{
				streamTimer = 0.0f; 
				streamState = 2;
			}
		} else if (streamState == 2)
		{
			stream1.transform.parent = null;
			stream2.transform.parent = null;
			stream1.transform.localPosition += new Vector3(0,0, -Time.deltaTime * 2);
			stream2.transform.localPosition += new Vector3(0,0, -Time.deltaTime * 2);
			streamTimer += Time.deltaTime;
			if(streamTimer >= leaveTime)
			{
				streamTimer = 0.0f; 
				streamState = 0;
			}
		}
	
	}

	public void streamIt()
	{
		stream1.transform.localScale = new Vector3(stream1.transform.localScale.x, 0, stream1.transform.localScale.z);
		stream2.transform.localScale = new Vector3(stream2.transform.localScale.x, 0, stream2.transform.localScale.z);
		stream1.transform.parent = this.gameObject.transform;
		stream2.transform.parent = this.gameObject.transform;
		streamState = 1;

	}
}
