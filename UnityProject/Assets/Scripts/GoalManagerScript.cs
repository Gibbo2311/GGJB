using UnityEngine;
using System.Collections;

public class GoalManagerScript : MonoBehaviour {
	private bool inEndZone = false;	

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


		if (inEndZone) {
			Application.LoadLevel ("EndScene");
		}
	}

	void OnTriggerStay(Collider collider){
		inEndZone = false;
		if (collider.CompareTag ("Player")) {
			inEndZone = true;
		}
	}
}
