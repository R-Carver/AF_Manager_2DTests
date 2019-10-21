using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lineman
{
    public class OLiner_Movement : MonoBehaviour
    {   
        public Transform target;
        public Lineman_States state = Lineman_States.Run;

        public float speed;

        void Start()
        {
            
        }

        void Update()
        {
            if(state == Lineman_States.Run)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }else
            {
                
            }
        }
    }
}

