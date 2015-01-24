using UnityEngine;
using System.Collections;

public class SpotlightController : MonoBehaviour {
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
		if (getTwistStatus ().IsNoLightWhileMovement ()) {
			light.intensity = 0.0f;
		} else {
			light.intensity = 1.0f;
		}

	}
}
