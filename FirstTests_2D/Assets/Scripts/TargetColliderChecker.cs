using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetColliderChecker : MonoBehaviour
{   
    public UnityEvent TargetEntered;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            TargetEntered.Invoke();
            Debug.Log("Player Entered");
        }
    }
}
