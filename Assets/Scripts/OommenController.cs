using UnityEngine;
using System.Collections;

public class OommenController : MonoBehaviour {

	Transform player;
	Transform oommen;

	NavMeshAgent nav;
	private float speed;
	private float distFromPlayer;
	private float timeToChangeDirection;


	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		oommen = transform;
		nav = GetComponent<NavMeshAgent> ();

	}

	void Start () {
		ChangeDirection();

	}


	void Update () {

		distFromPlayer = Vector3.Distance(player.position, oommen.position);

		if (distFromPlayer < 15) {
			nav.SetDestination (player.position);
		} else {
			
			timeToChangeDirection -= Time.deltaTime;

			if (timeToChangeDirection <= 0) {
				ChangeDirection();
			}

			GetComponent<Rigidbody>().velocity = transform.up * 2;

		}
	}

	private void ChangeDirection() {
		float angle = Random.Range(0f, 360f);
		Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
		Vector3 newUp = quat * Vector3.up;
		newUp.z = 0;
		newUp.Normalize();
		transform.up = newUp;
		timeToChangeDirection = Random.Range(10f,60f);
	}




}
