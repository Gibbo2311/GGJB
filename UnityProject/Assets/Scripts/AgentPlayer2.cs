using UnityEngine;
using System.Collections;

public class AgentPlayer2 : Agent {
	private GameObject twistStatusObject;

	protected Vector3 look;
	// Use this for initialization
	public override void Start () {
		base.Start ();
		twistStatusObject = GameObject.FindGameObjectWithTag ("TwistStatus");
	}

	private TwistStatus getTwistStatus(){
		return twistStatusObject.GetComponent<TwistStatus> ();
	}
	
	float GetReverseFactor () {
		bool reversedControls = getTwistStatus ().IsReversedControls ();
		float reverseFactor = 1.0f;
		if (reversedControls) {
			reverseFactor = -1.0f;
		}
		return reverseFactor;
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
	public override void Update () {
		this.look = new Vector3(GetReverseFactor () * Input.GetAxis (mapInput("h")),
		                        0f,
		                        GetReverseFactor () * Input.GetAxis (mapInput("v")));

		this.transform.LookAt(this.transform.position + look);

	}
}