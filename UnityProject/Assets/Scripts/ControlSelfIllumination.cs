using UnityEngine;
using System.Collections;

public class ControlSelfIllumination : MonoBehaviour {

	public Color main_color = new Color(1f, 1f, 0f);

	public float color_multiplier = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.gameObject.renderer.material.color = this.main_color * color_multiplier;
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "SpotlightCollision")
		{
			
		}
	}
}
