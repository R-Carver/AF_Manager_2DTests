using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_DrawVectors : MonoBehaviour
{
    public PlayerMovement movementInfo;
    

    void Start()
    {
        Debug.Log("We have " + movementInfo.MovementVectors.Count + " Vectors");
    }

    void FixedUpdate() 
    {   
        foreach(Vector2 vector in movementInfo.MovementVectors)
        {
            Debug.DrawLine(this.transform.position, (Vector2)this.transform.position + vector, Color.gray);
        }
    }

    void UpdateVectors()
    {
        //since we dont want to draw the vectors according to the sensor information
        //which is changing continuously
        //instead we want to change them when the rb makes a new observation as called by the 
        //the GameController

        //loop through the sensors

        //add the vectors for the active sensors to the drawList
    }
}
