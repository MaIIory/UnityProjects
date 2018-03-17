using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {

	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public int speed;
	public Boundary boundary;
	public float tilt;
	public GameObject shoot;
	private float nextFire;
	public float fireRate;

	void Start() {

		rb = GetComponent<Rigidbody>();
		nextFire = 0.0f;
	}

	void Update(){

		if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {

			nextFire = Time.time + fireRate;
			Instantiate(shoot, transform.position, new Quaternion());

		}
	}

	void FixedUpdate() {

		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (horizontalMovement, 0.0f, verticalMovement);
		rb.velocity = movement * speed;

		rb.position = new Vector3 (Mathf.Clamp(rb.position.x,boundary.xMin,boundary.xMax),0.0f,Mathf.Clamp(rb.position.z,boundary.zMin,boundary.zMax));

		rb.rotation = Quaternion.Euler (rb.velocity.z * tilt,0.0f,rb.velocity.x * (-tilt));


	}

}
