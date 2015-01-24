using UnityEngine;
using System.Collections;

public class DetectSpotlightCollision : MonoBehaviour {
	private GameObject twistStatusObject;
	
	// Use this for initialization
	public void Start () {
		twistStatusObject = GameObject.FindGameObjectWithTag ("TwistStatus");
	}
	
	private TwistStatus getTwistStatus(){
		return twistStatusObject.GetComponent<TwistStatus> ();
	}

	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider other)
	{
		if (getTwistStatus ().IsNoLightWhileMovement ()) {
			return;
		}

		if(other.gameObject.CompareTag("Box"))
		{
			ControlSelfIllumination otherObject = (ControlSelfIllumination) other.gameObject.GetComponent(typeof(ControlSelfIllumination));
			otherObject.OnLight();
		}

	}
}
