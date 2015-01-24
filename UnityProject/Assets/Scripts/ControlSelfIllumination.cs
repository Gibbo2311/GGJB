using UnityEngine;
using System.Collections;

public class ControlSelfIllumination : MonoBehaviour {

	protected Color main_color = new Color(1f, 1f, 0f);

	protected float color_multiplier = 0.5f;

	public float illumination_rate = 0.4f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.color_multiplier -= Time.deltaTime * (this.illumination_rate / 2);
		this.color_multiplier = Mathf.Clamp(this.color_multiplier, 0.0f, 1.0f);
		this.gameObject.renderer.material.color = this.main_color * this.color_multiplier;
	}

	public void OnLight() {
	
		Debug.Log("Trigger with light");
		this.color_multiplier += illumination_rate * Time.deltaTime;
	}
}
