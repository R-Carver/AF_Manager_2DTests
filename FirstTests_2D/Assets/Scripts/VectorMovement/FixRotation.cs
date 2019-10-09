using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{   
    Quaternion startRotation;
    void Awake()
    {
        startRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.rotation = startRotation;
    }
}
