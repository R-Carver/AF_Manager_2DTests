using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor_ColliderChecker : MonoBehaviour
{   

    public Sensor_SO sensorInfo;
    public UnitySTypeEvent Event;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Event.Invoke(sensorInfo.type);
    }   
}
