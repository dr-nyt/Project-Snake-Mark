using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Private Variables
    [SerializeField]
    private Rigidbody playerBody;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private int coins;
    [SerializeField]
    private TMPro.TextMeshProUGUI coinText;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            game.ReloadCurrentLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Coin":
                coins++;
                Destroy(other.gameObject);

                coinText.text = string.Format("Coins\n{0}", coins);
                break;
            
            case "Goal":
                other.GetComponent<Goal>().checkForCompletion(coins);
                break;
            
            default:
                break;
        }
        
    }
















    /*
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
    }*/
}
