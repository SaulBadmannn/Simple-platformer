using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0;
    Animator animator;
    Rigidbody2D rigidbody2D;
    float directionRobot = 1f;
    bool isGround = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Ground>(out Ground ground))
        {
            isGround = true;
        }
    }

    private  void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Ground>(out Ground ground)) 
        {
            isGround = false;
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            Debug.Log("Робот идёт вправо");
            directionRobot = 1f;
            animator.SetFloat("Speed", horizontalInput);
        }
        else if (horizontalInput < 0)
        {
            Debug.Log("Робот идёт влево");
            directionRobot = -1f;
            animator.SetFloat("Speed", horizontalInput * -1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        transform.localScale = new Vector3(directionRobot, 1f, 1f);
        transform.position = transform.position + new Vector3(horizontalInput * _speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.UpArrow) && isGround)
        {
            rigidbody2D.AddForce(Vector2.up * 0.01f);
        }
    }
}
