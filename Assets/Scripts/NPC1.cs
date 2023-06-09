using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC1 : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public Rigidbody2D rb;
    public Animator anim;
    private Vector3 directionState;
    private Transform transformMove;
    public Collider2D bounds;
    // public Vector2 newVector2; Collision direction debugging purposes

    public GameObject dialogText;                                                      
    public Text dialogDesc;                                                             
    public string dialog;                                                               
    public bool dialogActive;                                                          
    public bool PlayerInRange;

    private void Start()
    {
        transformMove = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.E) && PlayerInRange)
        {
            if (dialogText.activeInHierarchy)
            {
                dialogText.SetActive(false);
            }
            else
            {
                dialogText.SetActive(true);
                dialogDesc.text = dialog;
            }
        }
    }

    
    private void Move()
    {
        
        rb.MovePosition(transformMove.position + directionState * movementSpeed * Time.deltaTime);                              //Moves the NPC without key input
        
    }
    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);                                                             //4 directions to move in, each direction is assigned to a case
        switch (direction)
        {
            case 0:                                 //Walk right
                directionState = Vector3.right;
                break;
            case 1:                                 //Walk left
                directionState = Vector3.up;
                break;
            case 2:                                //Walk up
                directionState = Vector3.left;
                break;
            case 3:                                 //Walk up
                directionState = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }
    void UpdateAnimation()
    {
        anim.SetFloat("MovementX", directionState.x);                                       //Sets the horizontal animation when on X plane
        anim.SetFloat("MovementY", directionState.y);                                       //Same but on Vertical plane
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 temp = directionState;                                          //Create a variable to store the temporary direction the NPC is facing
        ChangeDirection();                                                          //Change its direction
        int loops = 0;
        while (temp == directionState && loops < 50)                                //As long as the direction its facing is equal to its direction state, then its direction is able to change upon collision
        {
            loops++;
            ChangeDirection();
        }
        //if(newVector2 == Vector2.left)
        //{
        //    newVector2 = Vector2.right;
        //}
        //else if (newVector2 == Vector2.right)
        //{
        //    newVector2 = Vector2.left;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
            dialogText.SetActive(false);
        }
    }
}
