using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwistStatus : MonoBehaviour {
	private static int NO_LIGHTS_WHILE_MOVING = 0;
	private static int REVERSED_CONTROLS = 1;
	private static int SWITCHED_CONTROLS = 2;
	private static int BUTTON_NEEDED = 3;
	private static int BUTTON_NEEDED_SWITCHED = 4;

	public bool[] _twists = new bool[5];

	public int _maxParallelTwists = 3;
	public int _actualParallelTwists = 0;

	public bool _timeBasedTwist = true;
	public float _twistInterval = 15.0f;
	public float _startEscalationInterval = 15.0f;
	private float _actualEscalationInterval = 15.0f;
	public float _standardEscalationInterval = 45.0f;
	private float _lastTwistsChange = 0.0f;
	private float _lastTwistsEscalation = 0.0f;

	private bool _charMoving = false;

	// Use this for initialization
	void Start () {
		_actualEscalationInterval = _startEscalationInterval;
	}
	
	// Update is called once per frame
	void Update () {
		TimeBasedTwist ();	
	}

	void TimeBasedTwist ()
	{
		if (!_timeBasedTwist) {
			return;
		}

		_lastTwistsEscalation = _lastTwistsEscalation + Time.deltaTime;
		if (_lastTwistsEscalation > _actualEscalationInterval) {
			_actualEscalationInterval = _standardEscalationInterval;
			if(_actualParallelTwists < _maxParallelTwists) {
				_actualParallelTwists++;
			}
			_lastTwistsEscalation=0f;
		}

		_lastTwistsChange = _lastTwistsChange + Time.deltaTime;
		if (_lastTwistsChange > _twistInterval) {
			switchOnTwists ();
			_lastTwistsChange = 0f;
		}
	}

	void switchOnTwists(){
		List<int> candidates = new List<int>();
		// clear all twists;
		for (int i = 0; i < _twists.Length; i++) {
			_twists[i] = false;
			candidates.Add(i);
		}

		for (int i = 0; i < _actualParallelTwists; i++) {
			int removeCandidateIndex = Random.Range(0,candidates.Count);
			int twistIndex = candidates[removeCandidateIndex];
			_twists[twistIndex] = true;
			//Debug.Log("Turning on Twist ["+twistIndex+"]");
			candidates.Remove(removeCandidateIndex);
		}
	}

	public bool IsNoLightWhileMovement(){
		return  _charMoving && _twists[NO_LIGHTS_WHILE_MOVING];
	}

	public void SetNoLightWhileMovement(bool b){
		_twists[NO_LIGHTS_WHILE_MOVING] = b;			
	}

	public bool IsReversedControls(){
		return _twists[REVERSED_CONTROLS];
	}
	
	public void SetReversedControls(bool b){
		_twists[REVERSED_CONTROLS] = b;
	}

	public bool IsSwitchedControls(){
		return _twists[SWITCHED_CONTROLS];
	}
	
	public void SetSwitchedControls(bool b){
		_twists[SWITCHED_CONTROLS] = b;
	}
	
	public bool IsButton1Needed(){
		if(!_twists[BUTTON_NEEDED] && !_twists[BUTTON_NEEDED_SWITCHED]){
			return false;
		}

		bool buttonPressed = false;

		if (_twists [BUTTON_NEEDED_SWITCHED]) {
			buttonPressed = Input.GetAxis ("Fire2") > 0.0f;
		} else {
			buttonPressed = Input.GetButton ("Fire1");
		}

		return !buttonPressed;
	}

	public bool IsButton2Needed(){
		if(!_twists[BUTTON_NEEDED] && !_twists[BUTTON_NEEDED_SWITCHED]){
			return false;
		}

		bool buttonPressed = false;

		if (_twists [BUTTON_NEEDED_SWITCHED]) {
			buttonPressed = Input.GetButton ("Fire1");
		} else {
			buttonPressed = Input.GetAxis ("Fire2") > 0.0f;
		}

		return !buttonPressed;
	}

	public void SetButtonNeeded(bool b){
		_twists[BUTTON_NEEDED] = b;
	}
	
	public void SetCharMoving(bool b) {
		_charMoving = b;
	}
}
