using UnityEngine;
using System.Collections;

public class TopDownCameraFollow : MonoBehaviour {
	public Transform _toFollow;
	public float _height = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = new Vector3 ();
		v = _toFollow.transform.position;
		v.y = v.y + _height;	
		transform.position = v;
	}
}
