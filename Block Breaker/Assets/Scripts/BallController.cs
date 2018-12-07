using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private PaddleController _paddle;
    private Vector3 _offsetToPaddle;
    private bool _isLaunched;
    private Rigidbody2D _rb;

    public bool IsLaunched
    {
        get { return _isLaunched; }
    }

    // Use this for initialization
    void Start()
    {

        _paddle = FindObjectOfType<PaddleController>();
        _offsetToPaddle = transform.position - _paddle.transform.position;
        _isLaunched = false;
        _rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!_isLaunched)
        {
            transform.position = _paddle.transform.position + _offsetToPaddle;

            if (Input.GetMouseButtonDown(0))
            {
                _isLaunched = true;
                _rb.velocity = new Vector2(2f, 10f);
            }
        }


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (_isLaunched)
        {



            _rb.velocity = new Vector2(_rb.velocity.x + Random.Range(-0.5f, 0.5f), _rb.velocity.y);

            //adjust vertical speed (should be constant)
            if (_rb.velocity.y >= 0)
                _rb.velocity = new Vector2(_rb.velocity.x, 8);
            else 
                _rb.velocity = new Vector2(_rb.velocity.x, -8);

            //adjust horizontal speed
            if (_rb.velocity.x >= 0)
                _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x,2,7), _rb.velocity.y);
            else
                _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -7, -2), _rb.velocity.y);


        }

        Debug.Log("AFTER x velocity: " + _rb.velocity.x + ", y velocity: " + _rb.velocity.y);
    }
}
