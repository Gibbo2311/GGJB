using UnityEngine;
using System.Collections;

public class DetectSpotlightCollision : MonoBehaviour {
	private GameObject twistStatusObject;

	private GameObject flashlightObject;

	// Use this for initialization
	public void Start () {
		twistStatusObject = GameObject.FindGameObjectWithTag ("TwistStatus");

		flashlightObject = GameObject.FindGameObjectWithTag ("Player2");
	}
	
	private TwistStatus getTwistStatus(){
		return twistStatusObject.GetComponent<TwistStatus> ();
	}

	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider other)
	{
		if (getTwistStatus ().IsNoLightWhileMovement () || getTwistStatus().IsButton2Needed()) {
			return;
		}

		if(other.gameObject.CompareTag("Box"))
		{
			ControlSelfIllumination otherObject = (ControlSelfIllumination) other.gameObject.GetComponent(typeof(ControlSelfIllumination));
			//var layerMask = 1 << 2;
			RaycastHit hit;
			Vector3 raytraceStart = flashlightObject.transform.position;
			raytraceStart.y += 0.2f;
			Vector3 direction = other.gameObject.transform.position - raytraceStart; 
			direction.y += 0.1f;
			direction.Normalize();
			if(Physics.Raycast (raytraceStart, direction, out hit,  20f))
			{
				if(hit.collider == other)
				{
					otherObject.OnLight();
				}
			}
		}
		else if(other.gameObject.CompareTag("WallCube"))
		{
			ControlSelfIllumination otherObject = (ControlSelfIllumination) other.gameObject.GetComponent(typeof(ControlSelfIllumination));
			otherObject.OnLight();
		}
		
	}
}
