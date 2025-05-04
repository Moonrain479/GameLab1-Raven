using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{

    private Rigidbody2D player;
    public float JumpPower;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orb") && Input.GetButton("Jump"))
        {
            player.velocity = new Vector2(player.velocity.x, JumpPower);
        }
    }
}
