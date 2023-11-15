using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class daibanglo : MonoBehaviour
{
    public GameObject PointA;

    public GameObject PointB;

    private Rigidbody2D enemy;

    private Animator anim;

    private Transform currentPoint;
    

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        enemy = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointA.transform;
        anim.SetBool("isRun", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == PointB.transform)
        {
            enemy.velocity = new Vector2(speed, 0);
        }
        else
        {
            enemy.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == PointB.transform)
        {
            flip2();
            currentPoint = PointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == PointA.transform)
        {
            flip2();
            currentPoint = PointB.transform;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "player")
        {
            anim.SetBool("isRun", false);
            // anim.SetTrigger("attack");
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "player")
        {
            anim.SetBool("isRun", true);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "fireball" || other.gameObject.tag == "fireball2")
        {
            enemy.velocity = Vector2.zero;
            anim.SetTrigger("die");
            Destroy(gameObject, 1.5f);
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= 1;
        transform.localScale = localScale;
    }
    private void flip2()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 1f);
        Gizmos.DrawWireSphere(PointB.transform.position, 1f);
        Gizmos.DrawLine(PointB.transform.position, PointA.transform.position);
    }
}