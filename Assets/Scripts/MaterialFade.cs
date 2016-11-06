using UnityEngine;
using System.Collections;

public class MaterialFade : MonoBehaviour 
{
	[Range (0.1f, 1.0f)]
	public float fadeSpeed = 1f;    // How fast alpha value decreases.
	private Color fadeColor = new Color (0, 0, 0, 0);

	private Material m_Material0;   // Used to store material reference.
	private Material m_Material1; 
	private Color m_Color0;            // Used to store color reference.
	private Color m_Color1; 
	float alpha=0.0f;


	void Start ()
	{
		// Get reference to object's material.
		m_Material0 = GetComponent <SkinnedMeshRenderer> ().materials[0];
		m_Material1 = GetComponent <SkinnedMeshRenderer> ().materials[1];

		// Get material's starting color value.
		m_Color0 = m_Material0.color;
		m_Color1 = m_Material1.color;

		// Must use "StartCoroutine()" to execute 
		// methods with return type of "IEnumerator".


	}


	void Update(){
		
		if (GetComponent<ShadowFinder> ().InShadows) {
			StartCoroutine (AlphaFadeIn ());
		} else {
			StartCoroutine (AlphaFadeOut ());
		}
	}







	// This method fades only the alpha.
		IEnumerator AlphaFadeOut ()
	{
		// Alpha start value.
		//float alpha = 1.0f;

		// Loop until aplha is below zero (completely invisalbe)
		while (alpha > 0.0f)
		{
			// Reduce alpha by fadeSpeed amount.
			alpha -= fadeSpeed * Time.deltaTime;

			// Create a new color using original color RGB values combined
			// with new alpha value. We have to do this because we can't 
			// change the alpha value of the original color directly.
			m_Material0.color = new Color (m_Color0.r, m_Color0.g, m_Color0.b, alpha);
			m_Material1.color = new Color (m_Color1.r, m_Color1.g, m_Color1.b, alpha);

			yield return null;
		}
	}


	// This method fades from original color to "fadeColor"



	IEnumerator AlphaFadeIn ()
	{
		// Alpha start value.
		//float alpha = 0.0f;

		// Loop until aplha is below zero (completely invisalbe)
		while (alpha <= 1.0f)
		{
			// Reduce alpha by fadeSpeed amount.
			alpha += fadeSpeed * Time.deltaTime;

			// Create a new color using original color RGB values combined
			// with new alpha value. We have to do this because we can't 
			// change the alpha value of the original color directly.
			m_Material0.color = new Color (m_Color0.r, m_Color0.g, m_Color0.b, alpha);
			m_Material1.color = new Color (m_Color1.r, m_Color1.g, m_Color1.b, alpha);

			yield return null;
		}
	}





}