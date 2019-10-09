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
}
