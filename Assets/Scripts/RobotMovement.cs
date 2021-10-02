using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class RobotMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private float _directionRobot = 1f;
    private bool _isGround = false;
    private const string _isRun = "IsRun";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Ground>(out Ground ground))
        {
            _isGround = true;
        }
    }

    private  void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Ground>(out Ground ground)) 
        {
            _isGround = false;
        }
    }

    private void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal");


        if (horizontalInput > 0)
        {
            Debug.Log("Робот идёт вправо");
            _directionRobot = 1f;
            _animator.SetBool(_isRun, true);
        }
        else if (horizontalInput < 0)
        {
            Debug.Log("Робот идёт влево");
            _directionRobot = -1f;
            _animator.SetBool(_isRun, true);
        }
        else
        {
            _animator.SetBool(_isRun, false);
        }

        transform.localScale = new Vector3(_directionRobot, 1f, 1f);
        transform.position = transform.position + new Vector3(horizontalInput * _speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.UpArrow) && _isGround)
        {
            _rigidbody2D.AddForce(Vector2.up * 0.01f);
        }
    }
}
