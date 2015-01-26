using UnityEngine;
using System.Collections;

public class ShowScreen : MonoBehaviour {


	public Texture aTexture;
	void OnGUI() {
		if (!aTexture) {
			Debug.LogError("Assign a Texture in the inspector.");
			return;
		}
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), aTexture, ScaleMode.ScaleToFit, false, 1.0F);
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetButtonDown("Fire2")) {
			Application.LoadLevel("MainScene");										
		}
	}
}
