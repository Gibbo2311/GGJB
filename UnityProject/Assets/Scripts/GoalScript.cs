using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {
	public Color goal_color = new Color(0.5f, 0.5f, 0.5f);

	public bool complete = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.complete && this.particleSystem.isStopped)
		{
			gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			this.complete = true;
			this.particleSystem.Play();
			this.renderer.enabled = false;
		}
	}
}
