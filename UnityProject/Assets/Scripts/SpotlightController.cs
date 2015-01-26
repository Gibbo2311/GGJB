using UnityEngine;
using System.Collections;

public class SpotlightController : MonoBehaviour {
	private GameObject twistStatusObject;

	public bool first_movement_detected = false;

	// Use this for initialization
	public void Start () {
		twistStatusObject = GameObject.FindGameObjectWithTag ("TwistStatus");
	}
	
	private TwistStatus getTwistStatus(){
		return twistStatusObject.GetComponent<TwistStatus> ();
	}

	private string mapInput(string s){
		if (getTwistStatus ().IsSwitchedControls ()) {
			if ("h".Equals (s)) {
				return "Player1Horizontal";
			}
			if ("v".Equals (s)) {
				return "Player1Vertical";
			}
		} else {
			if ("h".Equals (s)) {
				return "Player2Horizontal";
			}
			if ("v".Equals (s)) {
				return "Player2Vertical";
			}
		}
		Debug.LogError ("Unknown Input ["+s+"]");
		return "";
	}
	
	// Update is called once per frame
	void Update () {

		if(!first_movement_detected)
		{
			float input_h = Input.GetAxis(mapInput("h"));
			float input_v = Input.GetAxis(mapInput("v"));

			if(input_h > 0.3 || input_h < -0.3 || input_v > 0.3 || input_v < -0.3)
			{
				first_movement_detected = true;
				foreach(Transform child in this.transform)
				{
					child.gameObject.SetActive(true);
				}
			}

		}

		if (getTwistStatus ().IsNoLightWhileMovement () ||  !first_movement_detected) {
			light.intensity = 0.0f;
		} else {
			light.intensity = 1.0f;
		}

	}
}
