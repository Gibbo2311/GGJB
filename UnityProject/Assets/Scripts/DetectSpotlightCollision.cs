using UnityEngine;
using System.Collections;

public class DetectSpotlightCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.CompareTag("Box"))
		{
			Debug.Log ("On Collision Enter " + other.gameObject.name);
			ControlSelfIllumination otherObject = (ControlSelfIllumination) other.gameObject.GetComponent(typeof(ControlSelfIllumination));
			otherObject.OnLight();
		}

	}
}
