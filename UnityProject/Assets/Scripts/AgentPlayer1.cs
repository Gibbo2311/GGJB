using UnityEngine;
using System.Collections;

public class AgentPlayer1 : Agent {
	private GameObject twistStatusObject;

	public Vector3 twistFallMovement = Vector3.zero;

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
					return "Player2Horizontal";
			}
			if ("v".Equals (s)) {
					return "Player2Vertical";
			}
		} else {
			if ("h".Equals (s)) {
				return "Player1Horizontal";
			}
			if ("v".Equals (s)) {
				return "Player1Vertical";
			}
		}
		Debug.LogError ("Unknown Input ["+s+"]");
		return "";
	}

	// Update is called once per frame
	public override void Update () {
		if (getTwistStatus ().IsButton1Needed ()) {
			return;
		}

		float h = Input.GetAxis (mapInput("h"));
		float v = Input.GetAxis (mapInput("v"));

		sendCharMoving (h,v);

		this.move = new Vector3(GetReverseFactor () * h,
		                        0f, 
		                        GetReverseFactor () *  v);
		this.move.Normalize();

		if(getTwistStatus().IsFalling())
		{
			if(this.twistFallMovement == Vector3.zero)
			{
				float x_fall = Random.Range (-1.0f, 1.0f);
				float z_fall = Random.Range (-1.0f, 1.0f);
				
				this.twistFallMovement = new Vector3(x_fall, 0.0f, z_fall);
				this.twistFallMovement.Normalize();
				this.twistFallMovement *= (this.move_speed / 5.0f); 
			}
		}
		else
		{
			this.twistFallMovement = Vector3.zero;
		}

		this.move += this.twistFallMovement;

		this.transform.LookAt(this.transform.position + move);
		base.Update();
	}

	private void sendCharMoving(float h, float v){

		bool moving = (Mathf.Abs (h) > 0.1f) || (Mathf.Abs (v) > 0.1f);

		//Debug.LogWarning ("h["+h+"] v["+v+"] moving["+moving+"]");

		getTwistStatus().SetCharMoving(moving);			
	}

}