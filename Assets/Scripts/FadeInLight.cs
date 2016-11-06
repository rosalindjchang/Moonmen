using UnityEngine;
using System.Collections;

public class FadeInLight : MonoBehaviour {

	ShadowFinder shadowFinder;
	Color spriteColor;
	float rawTimer;
	float fadeLength;
	float fadeTimer;
	bool startFadeOut;
	bool startFadeIn;
	// Use this for initialization
	void Start () {
		shadowFinder = transform.parent.GetComponent<ShadowFinder> ();
		spriteColor = GetComponent<SpriteRenderer> ().color;
		rawTimer = 0;
		fadeLength = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
		rawTimer -= Time.deltaTime;
		if (rawTimer <= 0) {
			rawTimer = 0;
		}
		fadeTimer = 1-(rawTimer / fadeLength);

		/*if (shadowFinder.InShadows == true) {
			startFadeOut = false;
			Debug.Log ("in shadows");
		}

		if (shadowFinder.InShadows == false) {
			startFadeIn = false;
		}*/

		if (shadowFinder.InShadows==false && startFadeOut==false) {
			startFadeOut = true;
			rawTimer = fadeLength;
		}

		if(shadowFinder.InShadows==false && startFadeOut==true){
			spriteColor= Color.Lerp(new Color(1,1,1,1),new Color(1,1,1,0),fadeTimer);
		}


		if (shadowFinder.InShadows==true && startFadeIn==false) {
			startFadeIn = true;
			rawTimer = fadeLength;
		}

		if(shadowFinder.InShadows==true && startFadeIn==true){
			spriteColor= Color.Lerp(new Color(1,1,1,0),new Color(1,1,1,1),fadeTimer);
		
		}

	}
}
