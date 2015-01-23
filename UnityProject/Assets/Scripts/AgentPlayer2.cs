﻿using UnityEngine;
using System.Collections;

public class AgentPlayer2 : Agent {

	protected Vector3 look;
	// Use this for initialization
	public override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () {

		this.move = new Vector3(Input.GetAxis("Horizontal"),
		                        0f, 
		                        Input.GetAxis ("Vertical"));
		
		this.move.Normalize();

		base.Update();
	}
}