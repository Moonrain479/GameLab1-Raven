using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class invisWall : MonoBehaviour
{
    public TilemapRenderer tilemap;

    // Start is called before the first frame update
    void Start()
    { 
        tilemap = GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                tilemap.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tilemap.enabled = true;
        }
    }
}