using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BorderColliderChecker : MonoBehaviour
{   
    public UnityEvent BorderEntered;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            BorderEntered.Invoke();
            //Debug.Log("Player Entered");
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            BorderEntered.Invoke();
            //Debug.Log("Player is on Border");
        }
    }
}
