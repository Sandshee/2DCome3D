using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

	public Vector3 start;
	public Vector3 end;
	public float speed;
	public int wait;

	private bool forwards;
	private float dist;
	private int timer;

	// Use this for initialization
	void Start () {
		timer = 0;
		dist = 0;
		forwards = false;
		transform.localPosition = start;
	}

	// Update is called once per frame
	void FixedUpdate () {
		timer++;

		if (dist >= 1 && forwards) {
			forwards = false;
			timer = 0;
		} else if (dist <= 0 && !forwards) {
			forwards = true;
			timer = 0;
		}

		if (timer > wait) {
			if (forwards) {
				dist = dist + speed;
			} else {
				dist = dist - speed;
			}

            transform.localPosition = Vector3.Lerp (start, end, dist);
		}
			
	}
}
