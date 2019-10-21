using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lineman
{
    public class DLiner_ColliderChecker : MonoBehaviour
    {   
        //this component is on both lineman but only one of them should be used
        //so the first trigger should activate its battle
        //Lineman_Battle battle;

        private void OnCollisionEnter2D(Collision2D other)
        {   
            if(other.gameObject.tag == "OLiner")
            {
                Lineman_Battle myBattle = this.GetComponent<Lineman_Battle>();
                Lineman_Battle otherBattle = other.gameObject.GetComponent<Lineman_Battle>();

                //activate the battle on your GO if there is no active battle yet
                if (myBattle.enabled == false && otherBattle.enabled == false)
                {
                    myBattle.enabled = true;
                    myBattle.Test(this.tag);

                    //from now on the active battle is the battle on this GO thus "myBattle
                    myBattle.DLiner = this.gameObject;
                    myBattle.OLiner = other.gameObject;

                    myBattle.StartBattle();
                }
            }
            
        }

    }
}


