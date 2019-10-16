using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{   
    //store the dirVectors for each sensor 
    Dictionary<SensorType, Vector2> dirVectors = new Dictionary<SensorType, Vector2>();

    //the probController must be on the same GO as this ActionController
    ProbController probController;

    void OnEnable() 
    {   
        probController = this.GetComponent<ProbController>();
        InitVectors();
    }

    void InitVectors()
    {
        dirVectors.Add(SensorType.L, new Vector2(0f,1f));
        dirVectors.Add(SensorType.HL, new Vector2(1f,1f));
        dirVectors.Add(SensorType.FW, new Vector2(1f,0f));
        dirVectors.Add(SensorType.HR, new Vector2(1f,-1f));
        dirVectors.Add(SensorType.R, new Vector2(0f,-1f));
    }

    public Vector2 getDirVector()
    {   
        //this is based on the RandomSelection from the ProbController

        //get the correct sensor
        SensorType sensor = probController.getWeightedRandomSelection();

        return dirVectors[sensor];
    }
}
