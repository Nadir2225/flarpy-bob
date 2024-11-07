using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float deadZone = -45f;
    public LogicManager logic;
    public float initialPipeSpeed = 5f;  // Starting speed of pipes
    public float pipeSpeedIncreaseFactor = 0.001f;  // How much to increase pipe speed over time
    //public float maxPipeSpeed = 10f;  // Maximum pipe speed to prevent too fast pipes

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicManager>();
    }

    void Update()
    {
        Debug.Log(logic.pipeMoveSpeed);
        //Debug.Log(pipeSpeedIncreaseFactor);

        if (logic.gameActive && !logic.startingState)
        {
            // Increase pipe speed over time, clamped to maxPipeSpeed

            logic.pipeMoveSpeed = logic.pipeMoveSpeed + pipeSpeedIncreaseFactor * Time.deltaTime * 0.1f;

            // Move the pipe to the left
            transform.position += Vector3.left * logic.pipeMoveSpeed * Time.deltaTime;
        }

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
