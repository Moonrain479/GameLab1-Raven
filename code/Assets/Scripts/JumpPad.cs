using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
   
    private Rigidbody2D player;
    public float JumpPower;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("JumpPad"))
        {   
            player.velocity = new Vector2(player.velocity.x, JumpPower);
        }
    }
}
