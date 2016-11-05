using UnityEngine;
using System.Collections;

public class OommenController : MonoBehaviour {

	Transform player;
	Transform oommen;

	NavMeshAgent nav;
	private float speed;
	private float distFromPlayer;


	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		oommen = transform;
		nav = GetComponent<NavMeshAgent> ();
	}


	void Update () {

		distFromPlayer = Vector3.Distance(player.position, oommen.position);

		if (distFromPlayer < 20){
			nav.SetDestination (player.position);
		}
	}




}
