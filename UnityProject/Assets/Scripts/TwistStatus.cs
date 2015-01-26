using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwistStatus : MonoBehaviour {
	private const int NO_LIGHTS_WHILE_MOVING = 0;
	private const int REVERSED_CONTROLS = 1;
	private const int SWITCHED_CONTROLS = 2;
	private const int SEPARATED = 3;
	private const int FALLING = 4;

	private string getTwistName (int twistIndex){
		switch (twistIndex)
		{
		case NO_LIGHTS_WHILE_MOVING:
			return "No Light While Moving";
		case REVERSED_CONTROLS:
			return "Reversed Directions";
		case SWITCHED_CONTROLS:
			return "Switched Movement / Flashlight";
		case SEPARATED:
			return "Player and Flashlight Separated";
		case FALLING:
			return "Falling into random direction";
		default:
			return "New Twist!?!";
		}
	}
	


	public bool[] _twists = new bool[5];

	public int _maxParallelTwists = 3;
	public int _actualParallelTwists = 0;

	public bool _timeBasedTwist = true;
	public float _twistInterval = 15.0f;
	private float _actualTwistInterval = 15.0f;
	public float _startEscalationInterval = 15.0f;
	private float _actualEscalationInterval = 15.0f;
	public float _standardEscalationInterval = 45.0f;
	private float _lastTwistsChange = 0.01f;
	private float _lastTwistsEscalation = 0.0f;
	private bool _actualEscalationDecreasing = false;

	private bool _charMoving = false;

	// Use this for initialization
	void Start () {
		_actualEscalationInterval = _startEscalationInterval;
		_actualTwistInterval = _startEscalationInterval+0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		TimeBasedTwist ();	
		if (Input.GetKeyDown (KeyCode.F1)) {
			_debugActive = !_debugActive;
		}
	}

	public bool twistJustHappened()
	{
		return _lastTwistsChange == 0;
	}

	void TimeBasedTwist ()
	{
		if (!_timeBasedTwist) {
			return;
		}

		_lastTwistsEscalation = _lastTwistsEscalation + Time.deltaTime;
		if (_lastTwistsEscalation > _actualEscalationInterval) {
			_actualEscalationInterval = _standardEscalationInterval;

			if(_actualEscalationDecreasing) {
				if(_actualParallelTwists > 1) {
					_actualParallelTwists--;
				} else {
					_actualEscalationDecreasing=false;
				}
			} else {
				if(_actualParallelTwists < _maxParallelTwists) {
					_actualParallelTwists++;
				} else {
					_actualEscalationDecreasing=true;
				}
			}

			_lastTwistsEscalation=0f;
		}

		_lastTwistsChange = _lastTwistsChange + Time.deltaTime;
		if (_lastTwistsChange > _actualTwistInterval) {
			_actualTwistInterval = _twistInterval;
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
		_msgActiveTwists = "";

		for (int i = 0; i < _actualParallelTwists; i++) {
			int removeCandidateIndex = Random.Range(0,candidates.Count);
			int twistIndex = candidates[removeCandidateIndex];
			_twists[twistIndex] = true;

			string separator = " | ";
			if(i==0){
				separator = "";
			}
			_msgActiveTwists = _msgActiveTwists + separator + getTwistName(twistIndex);

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

	public void SetCharMoving(bool b) {
		_charMoving = b;
	}

	public bool IsSeparated(){
		return _twists[SEPARATED];
	}
	
	public void SetSeparated(bool b){
		_twists[SEPARATED] = b;
	}
	
	public bool IsFalling(){
		return _twists[FALLING];
	}
	
	public void SetFalling(bool b){
		_twists[FALLING] = b;
	}
	
	private bool _debugActive = false;
	private string _msgActiveTwists = "";
	

	void OnGUI () {
		// Make a background box
		//GUI.Box (new Rect (10, 10, 800, 600), "Active Twists: " + _msgActiveTwists);
		if (_debugActive) {
			GUI.Box(new Rect(0, 0, Screen.width, 20), _actualParallelTwists + " Twists: "+ _msgActiveTwists);
			//GUI.Box(new Rect(0, 20, Screen.width, Screen.height), "_lastTwistsChange["+Mathf.Round(_lastTwistsChange)+"] _lastTwistsEscalation["+Mathf.Round(_lastTwistsEscalation)+"] _actualEscalationDecreasing[" + _actualEscalationDecreasing +"]" );
		}
	}
	
	private void setMsgActiveTwists(string msg){
		_msgActiveTwists = msg;
	}


}
