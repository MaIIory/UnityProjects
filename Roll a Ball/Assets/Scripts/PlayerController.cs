using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


	public float speed;
	private Rigidbody rb;
	public Text textCount;
	public Text winText;
	public bool letJump;

	private int count;

	void Start () {
	
		rb = GetComponent<Rigidbody> ();
		count = 0;
		UpdateCountText ();
		winText.text = "";
		letJump = true;
	}

	void Update()
	{
		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();

		if (SystemInfo.deviceType != DeviceType.Desktop) {

			int fingerCount = 0;
			foreach (Touch touch in Input.touches) {
				if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
					fingerCount++;
			
			}
			if (fingerCount > 0)
				print ("User has " + fingerCount + " finger(s) touching the screen");
		}
	}

	void FixedUpdate () {

		if (SystemInfo.deviceType == DeviceType.Desktop) {

			float hor_movement = Input.GetAxis ("Horizontal");
			float ver_movement = Input.GetAxis ("Vertical");

			Vector3 vector_movement = new Vector3 (hor_movement, 0.0f, ver_movement);

			rb.AddForce (vector_movement * speed);

			if ((Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.JoystickButton0)) && letJump) {

				rb.AddForce (new Vector3 (0.0f, 10.0f, 0.0f), ForceMode.Impulse);
				letJump = false;
			}
		} else {

			// Building of force vector 
			Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
			// Adding force to rigidbody
			rb.AddForce(movement * speed * 120 * Time.deltaTime);

			int fingerCount = 0;
			foreach (Touch touch in Input.touches) {
				if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
					fingerCount++;
				
			}
			if (fingerCount > 0 && letJump){
				rb.AddForce (new Vector3 (0.0f, 10.0f, 0.0f), ForceMode.Impulse);
				letJump = false;
			}

		}
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.CompareTag("Ground"))
			letJump = true;	
	}

	
	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			UpdateCountText ();
		}
	}

	void UpdateCountText () {
		textCount.text = "Count: " + count.ToString();

		if (count >= 14)
			winText.text = "You Win!";
	}

}
