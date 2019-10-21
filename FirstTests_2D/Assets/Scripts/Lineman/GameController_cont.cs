using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lineman
{
    public class GameController_cont : MonoBehaviour
    {
        //here we assume that all the Controller Scripts are on the Player Object
        public GameObject Player;

        Movement_Controller_cont moveController;
        ProbController probController;

        void OnEnable()
        {
            moveController = Player.GetComponent<Movement_Controller_cont>();
            probController = Player.GetComponent<ProbController>();
        }
        
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("NextUpdate", 0.5f, 0.7f);
        }

        // Update is called once per frame
        void Update()
        {
            moveController.MoveStep();
        }

        void NextUpdate()
        {   
            probController.ResetProbs();
            probController.UpdateProbs();
            moveController.SetNextVector();

        }
    }
}

