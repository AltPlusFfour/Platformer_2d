using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyGraphics : MonoBehaviour
{

    public AIPath aipath;

    void Update()
    {
        if(aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3 (-1.94f, 1.94f, 1f);
        }
        else if (aipath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3 (1.94f, 1.94f, 1f);
        }
    }
}
