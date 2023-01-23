using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarController : MonoBehaviour
{
    public float movementSpeed;
    private Vector2 moveDirection;
    public Rigidbody2D rigidBody;
    public GameObject gameManager;
    GameManager gameController;
    public AudioClip collisionWater;
    public AudioClip collisionIce;


    // Start is called before the first frame update
    void Start()
    {
        gameController = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Processing Inputs
        ProcessInputs();
    }

    void FixedUpdate()
    {
        //Physics Calculations
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);
    }

    void Move()
    {
        Vector3 movement = new Vector3(movementSpeed * moveDirection.x, movementSpeed * moveDirection.y, 0f);
        rigidBody.AddForce(movement, ForceMode2D.Impulse);
        //rigidBody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Igloo")
        {
            gameController.winFunction();
        }

        if (collision.gameObject.tag == "Water")
        {
            gameController.audioSource.PlayOneShot(collisionWater);
            gameController.loseFunction();
        }
        if (collision.gameObject.tag == "Ice")
        {
            gameController.audioSource.PlayOneShot(collisionIce);
        }
    }

    
}
