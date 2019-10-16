using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor_ColliderChecker : MonoBehaviour
{   

    public Sensor_SO sensorInfo;
    public UnitySTypeEvent Event;

    Sensor mySensor;

    void OnEnable()
    {   
        mySensor = this.GetComponent<Sensor>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Event.Invoke(sensorInfo.type);

        mySensor.active = true;
        Debug.Log("Sensor active");
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
       mySensor.active = false;
       Debug.Log("Sensor not active");     
    }   
}
