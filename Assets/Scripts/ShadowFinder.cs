using UnityEngine;
using System.Collections;

public class ShadowFinder : MonoBehaviour {
	
	GameObject sun ;
	public bool InShadows;
	// Use this for initialization
	void Start () {
		sun = GameObject.Find ("Sun");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 sunPos = sun.transform.position - gameObject.transform.position;

		RaycastHit hit;

		if (Physics.Raycast (transform.position, sunPos, out hit))
		if (hit.collider.name == "Sun") {
			Debug.DrawLine (sun.transform.position, gameObject.transform.position);
			InShadows = false;
		} else {
			InShadows = true;
		}
	}

	}

