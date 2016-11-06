using UnityEngine;
using System.Collections;

public class MoonmenControl : MonoBehaviour {

	Transform oommen;
	Transform moonmen;
	Transform player;

	NavMeshAgent nav;
	private float speed;
	private float distFromPlayer;
	Vector3 randomPoint; 


	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		randomPoint = Random.insideUnitSphere*200;
		randomPoint.y = 0;
		oommen = GameObject.FindGameObjectWithTag ("oommen").transform;
		moonmen = transform;
		nav = GetComponent<NavMeshAgent> ();
	}


	void Update () {

		distFromPlayer = Vector3.Distance(player.position, moonmen.position);

		if (distFromPlayer < 30) {
			nav.SetDestination (oommen.position);
		} else {
			nav.SetDestination (randomPoint);

		}
	}




}
