using UnityEngine;
using System.Collections;

public class ControlSelfIllumination : MonoBehaviour {

	public Color main_color;

	public bool override_color = false;

	protected float color_multiplier = 0.5f;

	public float illumination_rate = 0.6f;

	public float illumination_decrease_rate = 0.2f;
	// Use this for initialization
	void Start () {
		if(!override_color)
		{
			this.main_color = this.gameObject.renderer.material.color;
		}
	}
	
	// Update is called once per frame
	void Update () {

		this.color_multiplier -= Time.deltaTime * this.illumination_decrease_rate;
		this.color_multiplier = Mathf.Clamp(this.color_multiplier, 0.0f, 1.0f);
		this.gameObject.renderer.material.color = this.main_color * this.color_multiplier;
	}

	public void OnLight() {
		this.color_multiplier += illumination_rate * Time.deltaTime;
	}
}
