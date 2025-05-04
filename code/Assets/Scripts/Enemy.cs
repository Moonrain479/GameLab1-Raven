using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D enemy;
    private Transform currentpoint;
    public float speed;
    public playerMovement playerMovement;
    private bool FacingRight = false;

    
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        currentpoint = pointB.transform;
        //Health = GetComponent<Health>();
    }

    void Update()
    {
        Vector2 point = currentpoint.position - transform.position;
        if (currentpoint == pointB.transform)
        {
            enemy.velocity = new Vector2(speed, 0);
        }
        else
        {
            enemy.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentpoint.position) < 0.5f && currentpoint == pointB.transform)
        {
            currentpoint = pointA.transform;
            Flip();
        }
        if (Vector2.Distance(transform.position, currentpoint.position) < 0.5f && currentpoint == pointA.transform)
        {
            currentpoint = pointB.transform;
            Flip();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerMovement.editMode == false) {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerMovement.KBCounter = playerMovement.KBTotalTime;
                if (collision.transform.position.x <= transform.position.x)
                {
                    playerMovement.KnockFromRight = true;
                }
                if (collision.transform.position.x > transform.position.x)
                {
                    playerMovement.KnockFromRight = false;
                }
                var healthComponent = collision.gameObject.GetComponent<Health>();



                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(3);
                }
            }
        }
    }
    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}    
