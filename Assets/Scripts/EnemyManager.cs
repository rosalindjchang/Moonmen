﻿using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 10f;
	public Transform[] spawnPoints;

	void Start () {
		InvokeRepeating ("Spawn", spawnTime, 30f);
	}
		
	
	void Spawn () {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}
}
