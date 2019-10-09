using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public int xRange = 2;
    public int yRange = 2;

    private Vector2 getRandomPos()
    {
        return new Vector2(Random.Range(-xRange, xRange+1), Random.Range(-yRange, yRange+1)); 
    }

    public void Respawn()
    {
        Vector2 newPos = this.getRandomPos();

        this.transform.position = getRandomPos();
    }

}
