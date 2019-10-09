using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ]
public class Sensor_SO : ScriptableObject
{
    public SensorType type;
}

public enum SensorType { L, HL, FW, HR, R};
