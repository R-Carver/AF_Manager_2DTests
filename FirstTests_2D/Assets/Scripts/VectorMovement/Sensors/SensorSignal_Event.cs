using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SensorSignal_Event : ScriptableObject
{
    private List<SensorSignal_Listener> listeners = new List<SensorSignal_Listener>();

    public void Raise(SensorType type)
    {
        for(int i = listeners.Count -1; i >= 0; i--)
            listeners[i].OnEventRaised(type);
    }

    public void RegisterListener(SensorSignal_Listener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(SensorSignal_Listener listener)
    {
        listeners.Remove(listener);
    }
}
