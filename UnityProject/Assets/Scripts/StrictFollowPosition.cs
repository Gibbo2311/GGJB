using UnityEngine;
using System.Collections;

public class StrictFollowPosition : MonoBehaviour {
	public GameObject toFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		transform.position = toFollow.transform.position;
		transform.position = toFollow.transform.position;
	}
}
