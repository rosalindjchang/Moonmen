using UnityEngine;
using System.Collections;

public class MoonmenControl : MonoBehaviour {

	Transform oommen;
	Transform moonmen;
	Transform player;

	NavMeshAgent nav;
	private float speed;
	private float distFromPlayer;


	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		oommen = GameObject.FindGameObjectWithTag ("oommen").transform;
		moonmen = transform;
		nav = GetComponent<NavMeshAgent> ();
	}


	void Update () {

		distFromPlayer = Vector3.Distance(player.position, moonmen.position);

		if (distFromPlayer < 30){
			nav.SetDestination (oommen.position);
		}
	}




}
