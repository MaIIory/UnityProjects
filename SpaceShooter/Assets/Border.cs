﻿using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		// Destroy everything that leaves the trigger
		Destroy(other.gameObject);
	}


}
