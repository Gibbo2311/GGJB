using UnityEngine;
using System.Collections;

public class AgentPlayer1 : Agent {
	private GameObject twistStatusObject;

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
		float h = Input.GetAxis ("Player1Horizontal");
		float v = Input.GetAxis ("Player1Vertical");

		sendCharMoving (h,v);

		this.move = new Vector3(GetReverseFactor () * h,
		                        0f, 
		                        GetReverseFactor () *  v);
		this.move.Normalize();
		this.transform.LookAt(this.transform.position + move);
		base.Update();
	}

	private void sendCharMoving(float h, float v){

		bool moving = (Mathf.Abs (h) > 0.1f) || (Mathf.Abs (v) > 0.1f);

		//Debug.LogWarning ("h["+h+"] v["+v+"] moving["+moving+"]");

		getTwistStatus().SetCharMoving(moving);			
	}

}