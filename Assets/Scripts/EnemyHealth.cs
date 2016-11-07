using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {


	public float sinkSpeed = 2.5f;


	bool isDead;
	bool isSinking;

	void Update () {
		if (isSinking) {
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		} 
	}
		

	void OnTriggerEnter (Collider col) {
		
		if (col.tag == "bullet") {
			StartSinking ();
		}
	}

	public void StartSinking () {
		GetComponent<NavMeshAgent> ().enabled = false;
		GetComponent<Rigidbody> ().isKinematic = true;
		isSinking = true;

		//Destroy (gameObject, 2f);
	}
}
