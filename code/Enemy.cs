using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public GameObject PointA;
public GameObject PointB;
private Rigidbody2D Enemy;
private BoxCollider2D col;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        Enemy = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
}

    // Update is called once per frame
    void Update()
    {

        player.velocity = new Vector2(Dx * 8f, player.velocity.y);

    }
}
