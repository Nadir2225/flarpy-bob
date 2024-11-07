using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdbody : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicManager logic;
    public float lowestY = -17;
    public float highestY = 18;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody.velocity = Vector2.zero;
        myRigidBody.gravityScale = 0f;
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && logic.gameActive)
        {
            logic.startingState = false;
            logic.startingUi.SetActive(false);
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
        if (transform.position.y < lowestY || transform.position.y > highestY)
        {
            logic.gameOver();
        }
        if (!logic.startingState && logic.gameActive)
        {
            //myRigidBody.velocity = Vector2.zero;
            myRigidBody.gravityScale = 2.8f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myRigidBody.velocity = Vector2.zero;
        myRigidBody.gravityScale = 0f;
        myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        myRigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
        logic.gameOver();
    }
}
