using UnityEngine;
using System.Collections;

public class FloorGenerator : MonoBehaviour {

	public int x_size = 50;

	public int z_size = 50;
	// Use this for initialization
	void Start () {

		for(int i = -x_size; i < x_size; i++)
		{
			for( int k = -z_size; k < z_size; k++)
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
