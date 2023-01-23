using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinController : MonoBehaviour
{
    public float movementSpeedX;
    public float movementSpeedY;
    public Vector2 movementDirection;
    public GameObject startingPoint;
    public GameObject endingPoint;
    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementSpeedX * movementDirection.x, movementSpeedY * movementDirection.y, 0f);
    }
}
