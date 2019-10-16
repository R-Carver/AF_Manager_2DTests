using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    ActionController actionController;

    void OnEnable()
    {
        actionController = this.GetComponent<ActionController>();
    }

    void Start()
    {
        //InvokeRepeating("MoveStep", 1, 3);
    }

    public void MoveStep()
    {   
        Debug.Log("next Round");
        //get the action which is choosen by the action controller
        //here we know that the action is a vector 
        Vector2 nextVector = actionController.getDirVector();

        //apply the movement to the player
        Vector2 target = (Vector2)transform.position + nextVector;

        //adjust rotation to move dir
        float angle = Mathf.Atan2(nextVector.y, nextVector.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        transform.rotation = rotation;
        transform.position = Vector3.MoveTowards(transform.position, target, 1);
    }
}
