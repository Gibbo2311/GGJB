using UnityEngine;
using System.Collections;

public class StrictFollowPosition : MonoBehaviour {
	public GameObject toFollow;

	private GameObject twistStatusObject;

	// Use this for initialization
	void Start () {
		twistStatusObject = GameObject.FindGameObjectWithTag ("TwistStatus");
	}

	private TwistStatus getTwistStatus(){
		return twistStatusObject.GetComponent<TwistStatus> ();
	}

	// Update is called once per frame
	void Update () {

		if(!getTwistStatus().IsSeparated())
		{
			transform.position = toFollow.transform.position;
		}
	}
}
