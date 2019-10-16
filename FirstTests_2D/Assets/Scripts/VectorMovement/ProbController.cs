using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbController : MonoBehaviour
{   
    public SensorController sensorController;   
    //store the probs for this instance
    Dictionary<SensorType, float> probs = new Dictionary<SensorType, float>();

    void OnEnable() 
    {
        InitProbs();
    }

    void Start()
    {
        //set the initial probs on the sensors
        InitSensorProbs();
    }

    void InitSensorProbs()
    {
        foreach(Sensor s in sensorController.sensors)
        {
            s.dirProb = probs[s.sensorInfo.type];
        }
    }

    void InitProbs()
    {
        //Initialize Dict
        probs.Add(SensorType.L, 0.1f);
        probs.Add(SensorType.HL, 0.2f);
        probs.Add(SensorType.FW, 0.4f);
        probs.Add(SensorType.HR, 0.2f);
        probs.Add(SensorType.R, 0.1f);
    }
    public void ResetProbs()
    {
        /* old version
        if(probs.Count == 0)
        {      
            Debug.Log("Prob Dict is empty");
            return;
            
        }else
        {
            probs[SensorType.L] = 0.1f;
            probs[SensorType.HL] = 0.2f;
            probs[SensorType.FW] = 0.4f;
            probs[SensorType.HR] = 0.2f;
            probs[SensorType.R] = 0.1f;
        }*/

        foreach(Sensor s in sensorController.sensors)
        {
            s.dirProb = probs[s.sensorInfo.type];
        }
    }

    public SensorType getWeightedRandomSelection()
    {
        float randomWeight = Random.Range(0.0f, 1.0f);

        /* old version
        foreach(var item in probs)
        {
            randomWeight = randomWeight - item.Value;
            if (randomWeight <= 0)
            {
                return item.Key;
            }
        }*/

        foreach(Sensor s in sensorController.sensors)
        {
            randomWeight = randomWeight - s.dirProb;
            if(randomWeight <= 0)
            {
                return s.sensorInfo.type;
            }
        }
        Debug.Log("No Random Selection - This should not happen");
        return SensorType.FW;
    }

    public void UpdateProbs()
    {
        float blockedProb = 0;

        //add up the blocked prob mass from sensors and set the blocked ones to 0
        foreach(Sensor s in sensorController.sensors)
        {
            if(s.active == true)
            {
                blockedProb += s.dirProb;
                s.dirProb = 0;
            }
        }
        //calculate new prob mass
        float remainingMass = 1.0f - blockedProb;

        //recalculate the prob mass for the remaining sensors
        foreach(Sensor s in sensorController.sensors)
        {
            if(s.active == false)
            {   
                //new proportions for remaining vectors
                s.dirProb = s.dirProb * (1.0f/remainingMass);

                //distribute the blocked probability
                s.dirProb = s.dirProb + (s.dirProb * blockedProb);
            }
        }
        
    }
}
