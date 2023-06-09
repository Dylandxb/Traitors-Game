using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string EnemyName;
    public float moveSpeed;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform locationPos;
    private Animator anim;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        CheckDistance();
        
    }


    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius /*&& Vector3.Distance(target.position,transform.position) > attackRadius*/)
        {
            transform.position = Vector3.MoveTowards(transform.position,target.position, moveSpeed * Time.deltaTime );
        }
    }

    public void Destroy()
    {

        anim.SetBool("Destroy", true);                                              //trigger destory animation when enemy has in hitbox range
        this.gameObject.SetActive(false);
        StartCoroutine(breakCoroutine());
    }

    IEnumerator breakCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        this.gameObject.SetActive(false);
    }

}
