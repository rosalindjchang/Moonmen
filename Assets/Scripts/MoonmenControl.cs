using UnityEngine;
using System.Collections;

public class MoonmenControl : MonoBehaviour {

	float speed;
	float originalspeed;


	void Start () {
		originalspeed = 0.01f;
		speed = originalspeed;

	}

	void Update () {

		// get the monster's current position
		Vector3 position = transform.position;

		//compute the monster's new position
		position = new Vector3 (position.x,position.y, position.z + speed + Time.deltaTime);

		//update enemy position
		transform.position = position;



	}




}
