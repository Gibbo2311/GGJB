﻿using UnityEngine;
using System.Collections;

public class AgentPlayer1 : Agent {
	
	// Use this for initialization
	public override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () {
		this.move = new Vector3(Input.GetAxis("Player1Horizontal"),
		                        0f, 
		                        Input.GetAxis ("Player1Vertical"));
		
		this.move.Normalize();
		
		this.transform.LookAt(this.transform.position + move);
		
		base.Update();
		
	}
}