using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    public GameObject dialogText;                                                       //Dialog image in canvas
    public Text dialogDesc;                                                             //Text contained within image
    public string dialog;                                                               //Assigns type string to dialog
    public bool dialogActive;                                                           //Sets whether the gameobject is active 
    public bool PlayerInRange;
    void Start()
    {

    }

    void Update()
    {
        StartCoroutine(showText());
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))                                                          //If the player collider has enter the sign collider, then playerInRange is true
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
            dialogText.SetActive(false);                                            //Deactivate gameObject when not in range
        }
    }

    IEnumerator showText()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerInRange)                                                    //Checks if player is in boundary
        {
            if (dialogText.activeInHierarchy)                                                   //If the gameObject is already active, then disable it upon pressing E
            {
                dialogText.SetActive(false);
            }
            else
            {
                dialogText.SetActive(true);
                dialogDesc.text = dialog;                                                   //Assigns the text UI to the text held in the inspector
            }

        }
        yield return null;
    }
}
