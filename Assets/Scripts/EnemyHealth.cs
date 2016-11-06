using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;

	ParticleSystem hitParticles;
	CapsuleCollider capsulecollider;
	bool isDead;
	bool isSinking;

	void Awake () {
		hitParticles = GetComponentInChildren <ParticleSystem> ();
		capsulecollider = GetComponent<CapsuleCollider> ();

		currentHealth = startingHealth;
	}



	void Update () {
		if (isSinking) {
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}

	public void TakeDamage (int amount, Vector3 hitPoint) {
		if (isDead)
			return;

		currentHealth -= amount;

		hitParticles.transform.position = hitPoint;
		hitParticles.Play ();

		if (currentHealth <= 0) {
			Death ();
		}
	}

	void Death () {
		isDead = true;

		capsulecollider.isTrigger = true;
	}

	public void StartSinking () {
		GetComponent<NavMeshAgent> ().enabled = false;
		GetComponent<Rigidbody> ().isKinematic = true;
		isSinking = true;

		Destroy (gameObject, 2f);
	}
}
