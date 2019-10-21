﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lineman
{
    public class Movement_Controller_cont : MonoBehaviour
    {
        ActionController actionController;

        Vector2 nextVector;

        void OnEnable()
        {
            actionController = this.GetComponent<ActionController>();
        }

        void Start()
        {
            SetNextVector();
        }

        public void MoveStep()
        {
            //apply the movement to the player
            Vector2 target = (Vector2)transform.position + nextVector;

            //adjust rotation to move dir
            float angle = Mathf.Atan2(nextVector.y, nextVector.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = rotation;
            transform.position = Vector3.MoveTowards(transform.position, target, 0.5f * Time.deltaTime);
        }

        public void SetNextVector()
        {
            //get the action which is choosen by the action controller
            //here we know that the action is a vector 
            nextVector = actionController.getDirVector();
        }

    }
}


