using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class Player_agent : Agent
{

    Quaternion startRotation;
    Vector2 startPosition;
    public override void InitializeAgent()
    {
        startRotation = transform.rotation;
        startPosition = transform.localPosition;
    }

    public override void AgentReset()
    {
        transform.localPosition = startPosition;
        transform.rotation = startRotation;
    }

    public override void CollectObservations()
    {
        AddVectorObs(this.transform.localPosition.x);
        AddVectorObs(this.transform.localPosition.y);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        MoveAgent(vectorAction);

        //small living punishment
        AddReward(-0.001f);
    }

    public void MoveAgent(float[] act)
    {
        // Alternative version for the movement:
        // The idea here is that we don't have to figure out the rotation, but we only move
        // Globally right-left and up-down and adjust the rotation after that

        Vector3 moveVertical = Vector3.zero;
        Vector3 moveHorizontal = Vector3.zero;

        // get the move signals
        int verticalSignal = (int) act[0];
        int horizontalSignal = (int) act[1];

        if(verticalSignal == 1)
            // move forward
            moveVertical = Vector3.up * 1f;
        else if(verticalSignal == 2)
            // move back
            moveVertical = Vector3.up * -1f;

        if(horizontalSignal == 1)
            // move left
            moveHorizontal = Vector3.right * -1f;
        else if(horizontalSignal == 2)
            // move right
            moveHorizontal = Vector3.right * 1f;

        Vector3 moveVector = moveHorizontal + moveVertical;
        //Debug.Log(moveVector);

        // only change the rotation when you have a movement in some direction
        if(!(verticalSignal == 0 && horizontalSignal == 0))
        {
            //Quaternion walkRotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            //transform.rotation = walkRotation;

            //transform.LookAt(moveVector, Vector3.back);
            float angle = Mathf.Atan2(moveVector.y, moveVector.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
        }

        Vector3 target = transform.position + moveVector;
        float speed = 1 * Time.deltaTime;
        
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }

    public void OnPlayerReachedTarget()
    {
        //Debug.Log("Reacting to Event");
        SetReward(1.0f);
        Done();
    }

    public void OnPlayerReachedBorder()
    {
        //Debug.Log("Reacting to Event");
        SetReward(-1.0f);
        Done();
        
    }
}
