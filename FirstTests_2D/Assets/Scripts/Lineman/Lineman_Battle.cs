using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lineman
{
    public class Lineman_Battle : MonoBehaviour
    {   
        public GameObject DLiner;
        public GameObject OLiner;

        public DLiner_Movement dLiner_mov;
        public OLiner_Movement oLiner_mov;
        
        void Start()
        {

        }

        void Update()
        {

        }

        public void Test(string tag)
        {
            Debug.Log(tag);
        }

        public void StartBattle()
        {   
            //first stop the movement of both
            dLiner_mov = DLiner.gameObject.GetComponent<DLiner_Movement>();
            oLiner_mov = OLiner.gameObject.GetComponent<OLiner_Movement>();

            
            //Debug.Log("DLiner " + DLiner);

            //Debug.Log("Movement Script " + dLiner_mov);
            dLiner_mov.state = Lineman_States.Battle;
            oLiner_mov.state = Lineman_States.Battle;

            //simple version of stochastic battle
            if(Random.Range(0.0f,1.0f) > 0.5)
            {
                //Dliner wins
                Invoke("DLiner_Wins", 1);

            }else
            {
                //Oliner wins

            }
        }

        void DLiner_Wins()
        {
            OLiner.SetActive(false);
            dLiner_mov.SetFinalTarget();
            dLiner_mov.state = Lineman_States.Run;

        }

        void OLiner_Wins()
        {

        }
    }
}


