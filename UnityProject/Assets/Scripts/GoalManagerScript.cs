using UnityEngine;
using System.Collections;

public class GoalManagerScript : MonoBehaviour {

	public GoalScript[] goals;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		foreach(var goal in this.goals)
		{
			if(!goal.complete)
			{
				return;
			}
		}

		if(this.particleSystem.isStopped)
		{
			this.particleSystem.Play();
		}
	}
}
