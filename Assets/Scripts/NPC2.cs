using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class NPC2 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] npcWaypoints;

    private IEnumerator teleportCoroutine;
    private float teleportInterval;
    private int stepCounter;


    private void Start()
    {
        teleportInterval = 4.0f;
        stepCounter = 0;
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            teleportCoroutine = Teleport();                         //Begins teleport after a trigger enter
            StartCoroutine(teleportCoroutine);
        }
    }

    //TRANSFORM THE PLAYER TO A NEWVECTOR AFTER EVERY COLLISION

    public IEnumerator Teleport()
    {
        while (true)
        {
            transform.position = new Vector3(npcWaypoints[stepCounter].transform.position.x, npcWaypoints[stepCounter].transform.position.y, 0);              //Transform position to each waypoint and increment the step counter
            stepCounter += 1;
            if (stepCounter > npcWaypoints.Length - 1)                              //If stepcounter is > the max number of waypoints then reset it first waypoint and disable NPC
            {
                stepCounter = 0;
                this.gameObject.SetActive(false);
            }
        
            yield return new WaitForSeconds(teleportInterval);          //Waits 5 seconds bbefore next teleport
            

        }
        

    }



}
