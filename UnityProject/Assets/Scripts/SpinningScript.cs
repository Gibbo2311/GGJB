using UnityEngine;
using System.Collections;

public class SpinningScript : MonoBehaviour {

	public float degrees_per_second = 50;

	private Vector3 initial_position;

	public Vector3 initial_offset;

	public float current_rotation = 0;
	// Use this for initialization
	void Start () {
		initial_offset = transform.localPosition;
		initial_position = transform.parent.position;
		transform.position = initial_position;

	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
		//transform.Rotate(0, this.degrees_per_second * Time.deltaTime, 0);
		current_rotation += degrees_per_second * Time.fixedDeltaTime;
		Quaternion qt = Quaternion.Euler(0, current_rotation, 0);
		
		Vector3 delta = qt *initial_offset; 
		Transform temp = this.transform;
		temp.position = new Vector3(temp.position.x, 0.5f, temp.position.z);
		temp.LookAt(transform.parent.position);

		this.rigidbody.MovePosition(initial_position + delta);
		this.rigidbody.MoveRotation(temp.localRotation);
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.CompareTag("Player"))
	    {
			//Debug.Log("COLLISION");
			//col.relativeVelocity * 2;
			col.gameObject.GetComponent<AgentPlayer1>().AddImpact(col.relativeVelocity * 2);

		}

	}
}
