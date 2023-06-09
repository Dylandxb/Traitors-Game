using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit: MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Breakable"))
        {
            other.GetComponent<Enemy>().Destroy(); //Trigger destory animation on any game object with a breakable tag
        }
    }
}
