using UnityEngine;
using System.Collections;

public class WorldBuilder : MonoBehaviour {

	public Terrain WorldTerrain;
	public LayerMask TerrainLayer;
	public static float TerrainLeft, TerrainRight, TerrainTop, TerrainBottom, TerrainWidth, TerrainLength, TerrainHeight;

	public static ArrayList units = new ArrayList();

	public void Awake() {

		TerrainLeft = WorldTerrain.transform.position.x;
		TerrainBottom = WorldTerrain.transform.position.z;
		TerrainWidth = WorldTerrain.terrainData.size.x;
		TerrainLength = WorldTerrain.terrainData.size.z;
		TerrainHeight = WorldTerrain.terrainData.size.y;
		TerrainRight = TerrainLeft + TerrainWidth;
		TerrainTop = TerrainBottom + TerrainLength;

		InstantiatefattreePosition ("tree", 300, 0f);
		InstantiatefattreePosition ("oommen", 300, 0f);

		InstantiateRandomPosition ("talltree", 300, 0f);
		InstantiatefattreePosition ("fattree", 50, 0f);
	}

	public void InstantiateRandomPosition(string Resource, int Amount, float AddedHeight) {

		//define variable
		var i = 0;
		float terrainHeight = 0f;
		RaycastHit hit;
		float randomPositionX, randomPositionY, randomPositionZ;
		Vector3 randomPosition = Vector3.zero;

		//loop through amount of times wanna instantiate
		do {
			i++;
			randomPositionX = Random.Range (TerrainLeft, TerrainRight);
			randomPositionZ = Random.Range (TerrainBottom, TerrainTop);

			//generate random position
			if (Physics.Raycast (new Vector3 (randomPositionX, 9999f, randomPositionZ), Vector3.down, out hit, Mathf.Infinity, TerrainLayer)) {
				terrainHeight = hit.point.y;
			}
			randomPositionY = terrainHeight + AddedHeight;

			randomPosition = new Vector3 (randomPositionX, randomPositionY, randomPositionZ);

			Instantiate (Resources.Load (Resource, typeof(GameObject)), randomPosition, Quaternion.identity);
				
		} while (i < Amount);

	}

		public void InstantiatefattreePosition(string Resource, int Amount, float AddedHeight) {

			//define variable
			var i = 0;
			float terrainHeight = 0f;
			RaycastHit hit;
			float randomPositionX, randomPositionY, randomPositionZ;
			Vector3 randomPosition = Vector3.zero;

			//loop through amount of times wanna instantiate
			do {
				i++;
				randomPositionX = Random.Range (TerrainLeft-(TerrainLeft*2/3),TerrainRight-(TerrainRight*2/3));
				randomPositionZ = Random.Range (TerrainBottom, TerrainTop);

				//generate random position
				if(Physics.Raycast (new Vector3(randomPositionX, 9999f, randomPositionZ), Vector3.down, out hit, Mathf.Infinity, TerrainLayer))
				{
					terrainHeight = hit.point.y;
				}
				randomPositionY = terrainHeight+AddedHeight;

				randomPosition = new Vector3(randomPositionX,randomPositionY,randomPositionZ);

				Instantiate(Resources.Load(Resource, typeof(GameObject)),randomPosition, Quaternion.identity);

			} while (i < Amount);

	}
	

}
