using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //here we assume that all the Controller Scripts are on the Player Object
    public GameObject Player;

    MovementController moveController;
    ProbController probController;

    void OnEnable() 
    {
        moveController = Player.GetComponent<MovementController>();
        probController = Player.GetComponent<ProbController>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NextRound", 1, 3);
    }

    void NextRound()
    {
        probController.UpdateProbs();
        moveController.MoveStep();
        probController.ResetProbs();
    }
}
