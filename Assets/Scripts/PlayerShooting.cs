using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public int damagePerShot = 50;
	public float timeBetweenBullets = 0.15f;
	public float range = 100f;

	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	ParticleSystem gunparticles;
	LineRenderer gunline;
	AudioSource gunAudio;
	Light gunLight;
	float effectsDisplayTime = 0.2f;

	void Awake () {
		shootableMask = LayerMask.GetMask ("Shootable");
		gunparticles = GetComponent<ParticleSystem> ();
		gunline = GetComponent<LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();
	}

	void Update () {
		timer += Time.deltaTime;

		if (Input.GetButton ("Fire1") && timer >= timeBetweenBullets) {
			Shoot ();
		}

		if (timer >= timeBetweenBullets * effectsDisplayTime) {
			DisableEffects ();
		}
	}

	public void DisableEffects () {
		gunline.enabled = false;
		gunLight.enabled = false;
	}


	void Shoot () {
		timer = 0f;
		gunAudio.Play ();
		gunLight.enabled = true;
		gunparticles.Stop ();
		gunparticles.Play ();

		gunline.enabled = true;
		gunline.SetPosition (0, transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.position;

		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth> ();
			if (enemyHealth != null) {
				enemyHealth.TakeDamage (damagePerShot, shootHit.point);
			}
			gunline.SetPosition (1, shootHit.point);
		} else {
			gunline.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}

	}
}
