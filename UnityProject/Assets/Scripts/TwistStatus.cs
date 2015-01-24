using UnityEngine;
using System.Collections;

public class TwistStatus : MonoBehaviour {
	public bool _noLightWhileMoventment = false;
	public bool _reversedControls = false;

	private bool _charMoving = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool IsNoLightWhileMovement(){
		return _noLightWhileMoventment;
	}

	public void SetNoLightWhileMovement(bool b){
		_noLightWhileMoventment = b;			
	}

	public bool IsReversedControls(){
		return _reversedControls;
	}
	
	public void SetReversedControls(bool b){
		_reversedControls = b;
	}

	public bool IsCharMoving() {
		return _charMoving;
	}
	public void SetCharMoving(bool b) {
		_charMoving = b;
	}
}
