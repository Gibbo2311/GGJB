using UnityEngine;
using System.Collections;

public class GoalCompleteScript : MonoBehaviour {

	public GoalScript goal;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(goal.complete && this.particleSystem.isStopped)
		{
			this.particleSystem.Play();
		}
	}
}
