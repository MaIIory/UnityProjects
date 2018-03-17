using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(15,30,40) * Time.deltaTime);
	}
}
