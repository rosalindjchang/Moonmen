using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Update () {
		Destroy (gameObject, 1f);
	}

	void OnTriggerEnter (Collider col) {
		if (col.tag == "moonmen") {
			Destroy (gameObject, 0f);
		} 
	}
}
