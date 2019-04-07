using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Game game;

    private float verticalVelocity;
    public float speed = 5;
    public float gravity = 14f;
    public float jumpForce = 10f;
    private Vector3 moveVector;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        game = FindObjectOfType<Game>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (jump)
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        jump = false;

        moveVector = transform.forward;
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = Input.GetAxisRaw("Vertical") * speed;
        //moveVector = new Vector3(Input.GetAxisRaw("Horizontal") * speed, verticalVelocity, Input.GetAxisRaw("Vertical") * speed);
        transform.LookAt(transform.position + new Vector3(moveVector.x, 0, moveVector.z));
        controller.Move(moveVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            game.ReloadCurrentLevel();
        }
    }
}














/*

    [SerializeField]
    private Rigidbody playerBody;

    [SerializeField]
    private float speed = 1f;

    public float jumpForce = 10f;
    public float jumpFall = 2.5f;
    public float lowJump = 2f;


    private bool jump;
    private Vector3 inputVector;

    private Game game;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        game = FindObjectOfType<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerBody.velocity = new Vector3(2f, playerBody.velocity.y, 2f);
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * speed, playerBody.velocity.y, Input.GetAxisRaw("Vertical") * speed);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (playerBody.velocity.y < 0)
        {
            playerBody.AddForce(Vector3.up * Physics.gravity.y * (jumpFall - 1), ForceMode.Impulse);
        }

        else if (playerBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerBody.AddForce(Vector3.up * Physics.gravity.y * (lowJump - 1), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        playerBody.velocity = inputVector;
        if(jump && IsGrounded())
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }
    }

    bool IsGrounded()
    {
        float distance = GetComponent<Collider>().bounds.extents.y + 0.3f;
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, distance);
    }*/
