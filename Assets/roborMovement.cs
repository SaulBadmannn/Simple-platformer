using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roborMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0;
    Animator animator;
    Rigidbody2D rigidbody2D;
    float directionRobot = 1f;
    bool is_ground = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            is_ground = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            is_ground = false;
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

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

        if (Input.GetKey(KeyCode.UpArrow) && is_ground)
        {
            rigidbody2D.AddForce(Vector2.up * 0.01f);
        }
    }
}
