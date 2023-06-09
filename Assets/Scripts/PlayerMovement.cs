using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public Rigidbody2D rb;
    public Animator animator;
    
    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetButtonDown("attack"))
        {
            StartCoroutine(attackStart());                                              //Animator not triggering destory animation after attack key is pressed
        }
        


    }

    private IEnumerator attackStart()
    {
        animator.SetBool("Attacking",true);
        yield return null;
        animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(0.33f);
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && Input.GetKey(KeyCode.Space))
        {

            Destroy(collision.gameObject);                                          //Deletes game object whilst colliding and attack animation is triggered with space bar
            
        }
    }

    
}
