using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    private BallController _ballController;
    public bool AutoControl = false;

	// Use this for initialization
	void Start () {
        _ballController = FindObjectOfType<BallController>();
	}


    // Update is called once per frame
    void Update () {

        if (!AutoControl)
        {
            float mousePosInUnits = Input.mousePosition.x / Screen.width * 16;
            transform.position = new Vector3(Mathf.Clamp(mousePosInUnits, 0.5f, 15.5f), transform.position.y, 0.0f);
        }
        else
        {
            transform.position = new Vector3(_ballController.transform.position.x, transform.position.y, 0.0f);
        }
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(_ballController.IsLaunched)
            GetComponent<AudioSource>().Play();
    }
}
