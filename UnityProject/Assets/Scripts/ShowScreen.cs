using UnityEngine;
using System.Collections;

public class ShowScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetButtonDown("Fire1")) {
			Application.LoadLevel("MainScene");										
		}
	}
}
