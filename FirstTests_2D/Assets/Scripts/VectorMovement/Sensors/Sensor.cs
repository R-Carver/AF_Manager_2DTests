using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{   

    public SensorController sensorController;
    public Sensor_SO sensorInfo;

    //the probability to take this direction
    public float dirProb;
    //active means the sensor has sensed and thus this dir is blocked
    public bool active = false;

    void OnEnable() 
    {   
        //Add yourself to the List of Sensors
        sensorController.sensors.Add(this);
    }
}
