using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lineman
{
    public class DLiner_Movement : MonoBehaviour
    {
        public Transform OlinerTarget;

        //this will typically be the QB, the RB or the Ball
        public Transform FinalTarget;
        Transform currentTarget;


        public Lineman_States state = Lineman_States.Run;

        public float speed;

        void Start()
        {
            currentTarget = OlinerTarget;
        }

        void Update()
        {   
            if(state == Lineman_States.Run)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

                //adjust rotation to move dir
                float angle = Mathf.Atan2(currentTarget.position.y - transform.position.y, currentTarget.position.x - transform.position.x) * Mathf.Rad2Deg;
                Debug.Log(angle);
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.localRotation = rotation;
                //transform.rotation = Quaternion.LookRotation(currentTarget.position);
            }else
            {

            }
            
        }

        public void SetFinalTarget()
        {
            currentTarget = FinalTarget;
        }
    }

}