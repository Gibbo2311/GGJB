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
	// Update is called once per frame
	public override void Update () {
		this.look = new Vector3(GetReverseFactor () * Input.GetAxis ("Player2Horizontal"),
		                        0f,
		                        GetReverseFactor () * Input.GetAxis ("Player2Vertical"));

		this.transform.LookAt(this.transform.position + look);

	}
}