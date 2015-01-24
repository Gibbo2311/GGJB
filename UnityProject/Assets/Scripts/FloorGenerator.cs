using UnityEngine;
using System.Collections;

public class FloorGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {

		for(int i = -50; i < 50; i++)
		{
			for( int k = -25; k < 25; k++)
			{
				GameObject go = (GameObject)Instantiate(Resources.Load("FloorPanel"));

				go.transform.parent = this.transform;
				go.transform.position = new Vector3(i, 0, k);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
