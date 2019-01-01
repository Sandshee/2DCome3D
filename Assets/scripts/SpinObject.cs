using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour {

    public bool up;
    public bool left;
    public bool forward;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (up) { this.transform.Rotate(Vector3.up); }
        if (left) { this.transform.Rotate(Vector3.left); }
        if (forward) { this.transform.Rotate(Vector3.forward); }
	}
}
