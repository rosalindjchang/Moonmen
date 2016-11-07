using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {


	public void Update () {

		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene ("DOGGY");
			SceneManager.UnloadScene ("START");

		}
	}

}
