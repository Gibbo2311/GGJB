using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Agent : MonoBehaviour {
	
	public float move_speed = 3.0f;
	
	protected CharacterController controller;
	
	protected Vector3 move = Vector3.zero;
	
	// Use this for initialization
	public virtual void Start () {
		
		this.controller = GetComponent<CharacterController>();
		
		if(!this.controller)
		{
			Debug.LogError("Agent.Start() " + this.name + " has no character controller");
		}
	}
	
	// Update is called once per frame
	public virtual void Update () {
		this.controller.SimpleMove(this.move * this.move_speed);
	}
}
