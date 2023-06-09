using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public GameObject wallOpening;                      //Assign the 2 wall gameObjects
    public GameObject Enemy;                            //Set Enemy as the skeleton gameObject

    private void Update()
    {
        if (wallOpening != null)                            //Checks if the wall openings do exist (are currently active)
        {
            if (Enemy == null)                              //Checks when Enemy has been destroyed (is null)
            {
                Destroy(wallOpening.gameObject);            //Then destroy the 2 pieces of wall to create the opening to escape
            }
        }
    }

}

