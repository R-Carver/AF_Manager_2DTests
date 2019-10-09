using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerMovement : ScriptableObject
{
    public List<Vector2> MovementVectors = new List<Vector2>();

    public void OnEnable()
    {   
        MovementVectors = new List<Vector2>();
        this.initMovementVectors();
    }

    private void initMovementVectors()
    {   
        //imagine the pitch for now from left to right
        //so the top-vector on the screen we interpret as left
        Vector2 vLeft = new Vector2(0,1);
        MovementVectors.Add(vLeft);

        Vector2 vHalfLeft = new Vector2(1,1);
        MovementVectors.Add(vHalfLeft);

        Vector2 vForward = new Vector2(1,0);
        MovementVectors.Add(vForward);

        Vector2 vHalfRight = new Vector2(1,-1);
        MovementVectors.Add(vHalfRight);

        Vector2 vRight = new Vector2(0,-1);
        MovementVectors.Add(vRight);
    }

}
