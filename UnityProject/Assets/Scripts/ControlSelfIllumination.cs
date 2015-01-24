using UnityEngine;
using System.Collections;

public class ControlSelfIllumination : MonoBehaviour {

	public Color self_color = new Color(0.3f, 1, 0.5f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.renderer.material.color = this.self_color;
	}
}
