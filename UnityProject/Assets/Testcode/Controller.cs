using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public float _speed = 10.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		transform.Translate (Vector3.left * ((_speed * -h) * Time.deltaTime));
		transform.Translate (Vector3.up * ((_speed * v) * Time.deltaTime));
	}
}
