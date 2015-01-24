using UnityEngine;
using System.Collections;

public class FloorGenerator : MonoBehaviour {

	public int x_size = 50;

	public int z_size = 50;
	// Use this for initialization
	void Start () {

		for(int i = -x_size; i <= x_size; i++)
		{
			for( int k = -z_size; k <= z_size; k++)
			{
				if(i == x_size || i == -x_size || k == z_size || k == -z_size)
				{
					GameObject wall = (GameObject)Instantiate(Resources.Load("WallCube"));
					
					wall.transform.parent = this.transform;
					wall.transform.position = new Vector3(i + 0.5f, 0.5f, k + 0.5f);
				}
				GameObject go = (GameObject)Instantiate(Resources.Load("FloorPanel"));

				go.transform.parent = this.transform;
				go.transform.position = new Vector3(i + 0.5f, 0, k + 0.5f);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
