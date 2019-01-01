using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject target = null;
	public Vector3 offset = Vector3.zero;
	public float speed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float xCoord = Mathf.Lerp (target.transform.position.x + offset.x, transform.position.x, speed);
		float yCoord = Mathf.Lerp (target.transform.position.y + offset.y, transform.position.y, speed);
		float zCoord = Mathf.Lerp (target.transform.position.z + offset.z, transform.position.z, speed);

		transform.position.Set(xCoord, yCoord, zCoord);

		transform.position = Vector3.Lerp (transform.position, target.transform.position + offset, speed);
	}
}
