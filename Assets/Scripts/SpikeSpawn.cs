using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject spikeSpawn;


    void Start()
    {
        spikeSpawn.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spikeSpawn.SetActive(true);
            Instantiate(spikeSpawn);
        }
    }
}
