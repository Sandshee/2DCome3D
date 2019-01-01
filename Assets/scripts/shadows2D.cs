using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadows2D: MonoBehaviour {

	// Use this for initialization
	void Start () {
		Renderer renderer = GetComponent<Renderer>();
		if (renderer == null)
			Debug.Log("Renderer is empty");
		GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;
		GetComponent<Renderer>().receiveShadows = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
