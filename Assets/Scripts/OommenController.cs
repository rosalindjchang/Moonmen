using UnityEngine;
using System.Collections;

public class OommenController : MonoBehaviour {

	Transform player;
	Transform moonmen;
	Transform oommen;
	Transform home;
	public GameObject oommenBod;

	NavMeshAgent nav;
	private float speed;
	private float distBetweenMoonOom;
	private float distFromPlayer;
	private float distFromeHome;
	private Animator oommenController;
	Vector3 randomPoint; 
	Transform getPos;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		randomPoint = Random.insideUnitSphere*200;
		randomPoint.y = 0;
		moonmen = GameObject.FindGameObjectWithTag ("moonmen").transform;
		home = GameObject.FindGameObjectWithTag ("Home").transform;
		oommen = transform;
		nav = GetComponent<NavMeshAgent> ();

	}
		
	void Update () {

		distFromeHome = Vector3.Distance(oommen.position, home.position);
		distFromPlayer = Vector3.Distance(player.position, oommen.position);
		distBetweenMoonOom = Vector3.Distance (oommen.position, moonmen.position);


		if (distFromPlayer < 20f) {
			nav.speed = 4.8f;

			if (distBetweenMoonOom < 20f) {
				nav.SetDestination (randomPoint);

			} else if (distFromeHome < 20f) {
				nav.SetDestination (home.position);
			} else {
				nav.SetDestination (player.position);
				}

		} else {
			nav.speed = 1.8f;
			nav.SetDestination (randomPoint);
		}

	}
		
}
