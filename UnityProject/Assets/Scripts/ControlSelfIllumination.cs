using UnityEngine;
using System.Collections;

public class ControlSelfIllumination : MonoBehaviour {

	public Color main_color = new Color(1f, 1f, 0f);

	public Color current_color = main_color;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.renderer.material.color = this.current_color;
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "SpotlightCollision")
		{

		}
	}
}
