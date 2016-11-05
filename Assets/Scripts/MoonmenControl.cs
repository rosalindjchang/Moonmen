using UnityEngine;
using System.Collections;

public class MoonmenControl : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	public float speed;


	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		nav = GetComponent<NavMeshAgent> ();
	}


	void Update () {
		nav.SetDestination (player.position);
	}




}
