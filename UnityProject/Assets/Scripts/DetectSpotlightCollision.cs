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
		if (getTwistStatus ().IsNoLightWhileMovement ()) {
			return;
		}

		if(other.gameObject.CompareTag("Box"))
		{
			ControlSelfIllumination otherObject = (ControlSelfIllumination) other.gameObject.GetComponent(typeof(ControlSelfIllumination));
			//var layerMask = 1 << 2;
			RaycastHit hit;
			Vector3 raytraceStart = flashlightObject.transform.position;
			raytraceStart.y += 0.3f;
			Vector3 direction = other.gameObject.transform.position - raytraceStart; 
			if (Physics.Raycast (raytraceStart, direction, out hit))
			{
				Vector3 v3Pos = hit.transform.position;
				//ray.
				if(hit.collider == other)
				{
					otherObject.OnLight();
					Debug.DrawLine(raytraceStart, v3Pos);
				}


			}


			
		}
		
	}
}
