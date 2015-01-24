using UnityEngine;
using System.Collections;

public class TopDownCameraFollow : MonoBehaviour {
	public Transform _toFollow;
	public float _speed = 10.0f;
	public float _startHeight = 100.0f;
	public float _targetHeight = 15.0f;
	private float _height = 15.0f;

	// Use this for initialization
	void Start () {
		StartCameraIntro ();			
	}

	public void StartCameraIntro(){
		_height = _startHeight;				
	}

	// Update is called once per frame
	void Update () {
		Vector3 v = new Vector3 ();
		v = _toFollow.transform.position;
		v.y = v.y + _height;	
		transform.position = v;

		if (_height > _targetHeight) {
			float distance = _speed * Time.deltaTime;

			_height = _height - distance;
			if(_height < _targetHeight) {
				_height = _targetHeight;
			}
		}

	}
}
