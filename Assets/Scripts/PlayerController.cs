using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject bulletprefab;
	public Transform bulletSpawn;
	float speed = 20;

	AudioSource gunAudio;


	void Awake () {
		gunAudio = GetComponent<AudioSource> ();

	}

	void Update () {
		
		if (Input.GetMouseButtonDown(0)) {
			Fire ();
			gunAudio.Play ();
		} 
	}

	void Fire () {
		GameObject Bullet = (GameObject)Instantiate (bulletprefab, bulletSpawn.position, bulletSpawn.rotation);
		Bullet.GetComponent<Rigidbody> ().velocity = Bullet.transform.forward*speed;

	}


}
