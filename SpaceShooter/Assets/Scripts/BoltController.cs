﻿using UnityEngine;
using System.Collections;

public class BoltController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}

}
