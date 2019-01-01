using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbPaperMovement : MonoBehaviour {

	public float speed = 4f;
	public float gravity = 9.81f;
	public float jumpVel = 2f;
	public float rotation = 0f;

	private Vector3 moveDir = Vector3.zero;
	private Rigidbody rb;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		sprite = GetComponent<SpriteRenderer> ();
	}

	void FixedUpdate () {
		moveDir.z = Input.GetAxisRaw ("Vertical");
		moveDir.x = Input.GetAxisRaw ("Horizontal");

		if (moveDir.x > 0) {
		} else if (moveDir.x < 0) {
		}

		rb.velocity = (moveDir.normalized * speed);
	}

	void Jump () {
		moveDir.y = jumpVel;
	}
}
