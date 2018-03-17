using UnityEngine;
using System.Collections;

public class PlatformRotationController : MonoBehaviour {

	public int rotationSpeed;

	// Update is called once per frame
	void Update () {

		transform.Rotate (new Vector3(15,0,0) * Time.deltaTime);
	
	}
}
