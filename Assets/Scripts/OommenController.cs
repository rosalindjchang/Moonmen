using UnityEngine;
using System.Collections;

public class OommenController : MonoBehaviour {

	Transform player;
	Transform moonmen;
	Transform oommen;
	public GameObject oommenBod;

	NavMeshAgent nav;
	private float speed;
	private float distBetweenMoonOom;
	private float distFromPlayer;
	private Animator oommenController;
	Vector3 randomPoint; 
	Transform getPos;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		//randomPoint = new Vector3(Random.Range(-8.0F, 8.0F), 0, Random.Range(-4.5F, 4.5F));
		randomPoint = Random.insideUnitSphere*200;
		randomPoint.y = 0;
		moonmen = GameObject.FindGameObjectWithTag ("moonmen").transform;
		oommen = transform;
		nav = GetComponent<NavMeshAgent> ();

	}
		

	void Update () {

		distFromPlayer = Vector3.Distance(player.position, oommen.position);
		distBetweenMoonOom = Vector3.Distance (moonmen.position, oommen.position);

		if (distFromPlayer < 15f) {
			nav.SetDestination (player.position);

			if (distBetweenMoonOom < 10f) {
				nav.SetDestination (randomPoint);
			}
				
		} else {
			nav.SetDestination (randomPoint);
		}

		
	}






}
