using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnitySTypeEvent : UnityEvent<SensorType>
{
    
}

public class SensorSignal_Listener : MonoBehaviour
{
    public SensorSignal_Event Event;
    //this is a unityEvent with a custom parameter of SensorType
    public UnitySTypeEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this);}

    private void OnDisable()
    { Event.UnregisterListener(this);}

    public void OnEventRaised(SensorType type)
    { Response.Invoke(type);}
}
