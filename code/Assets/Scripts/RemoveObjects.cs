using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RemoveObjects : MonoBehaviour
{
    
    public Collectibles collectibles;
    public playerMovement playerMovement;
    public GameMenu gameMenu;
    public GameObject FakePlayer;
    public bool destroyMode;
    float x;
    float y;
    public GameObject EditMode;
    public Rigidbody2D player;
   

    private void Start()
    {
        x = gameMenu.x;
        y = gameMenu.y;
    }
    private void Update()
    {
        if (playerMovement.editMode == false)
        {
            destroyMode = false;
            x = player.position.x;
            y = player.position.y;
        }

       

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (destroyMode == false)
            {
                playerMovement.editMode = true;
                FakePlayer.SetActive(true);
                EditMode.SetActive(true);
                destroyMode = true;
                Transform Fp = FakePlayer.transform;
                Fp.position = new Vector2(x, y);
            }
            //else
           // {
             //   playerMovement.editMode = false;
             //   FakePlayer.SetActive(false);
             //   EditMode.SetActive(false);
            //    destroyMode = false;
            //    player.position = new Vector2(x, y);            
            //}

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (destroyMode)
        {
            if (collision.gameObject.CompareTag("JumpPad"))
            {
                collectibles.colPads += 1;
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().Play("DeleteObject");
            }
            else if (collision.gameObject.CompareTag("Orb"))
            {
                collectibles.colOrbs += 1;
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().Play("DeleteObject");
            }
            else if (collision.gameObject.CompareTag("Box"))
            {
                collectibles.colBoxes += 1;
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().Play("DeleteObject");
            }
        }
    }

}
