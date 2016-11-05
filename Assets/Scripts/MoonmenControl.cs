using UnityEngine;
using System.Collections;

public class MoonmenControl : MonoBehaviour {

	Transform oommen;
	Transform moonmen;

	NavMeshAgent nav;
	private float speed;
	private float distFromPlayer;


	void Awake () {
		oommen = GameObject.FindGameObjectWithTag ("oommen").transform;
		moonmen = transform;
		nav = GetComponent<NavMeshAgent> ();
	}


	void Update () {

		distFromPlayer = Vector3.Distance(oommen.position, moonmen.position);

		if (distFromPlayer < 20){
			nav.SetDestination (oommen.position);
		}
	}




}
