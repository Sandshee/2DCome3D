using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustFloat : MonoBehaviour {
	public int lifeExpec;
	public float growSpeed;
	public float rotateSpeed;

	private SpriteRenderer spr;

	private int age = 0;

	// Use this for initialization
	void Start () {
		spr = GetComponent<SpriteRenderer> ();
		spr.transform.Rotate (0, 0, Random.Range(0,360));
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.localScale += new Vector3 (growSpeed, growSpeed, growSpeed);
		spr.transform.Rotate(Vector3.back * rotateSpeed);
		transform.Translate (Vector3.up*0.05f);
		age = age + 1;

		if (age >= lifeExpec) {
			Destroy(this.gameObject);
			print ("DEAD");
		}
	}
}
