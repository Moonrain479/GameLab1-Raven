using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    private int collectible = 0;
    public int AnzCol;

    public int colPads = 0;
    public int colOrbs = 0;
    public int colBoxes = 0;
    private BoxCollider2D col;

    public playerMovement playerMovement;
    

    [SerializeField] Text text;
    
    void Start()
    {
        
        col = GetComponent<BoxCollider2D>();
        text.text = "Collection: " + collectible + " / " + AnzCol;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerMovement.editMode == false)
        {
            if (collision.gameObject.CompareTag("colPads"))
            {
                FindObjectOfType<AudioManager>().Play("Collectibles");
                colPads++;
                collision.gameObject.SetActive(false);
                collectible++;
                text.text = "Collection: " + collectible + " / " + AnzCol;
            }
            else if (collision.gameObject.CompareTag("colOrbs"))
            {
                FindObjectOfType<AudioManager>().Play("Collectibles");
                colOrbs++;
                collision.gameObject.SetActive(false);
                collectible++;
                text.text = "Collection: " + collectible + " / " + AnzCol;
            }
            else if (collision.gameObject.CompareTag("colBoxes"))
            {
                FindObjectOfType<AudioManager>().Play("Collectibles");
                colBoxes++;
                collision.gameObject.SetActive(false);
                collectible++;
                text.text = "Collection: " + collectible + " / " + AnzCol;
            }
            if (collision.gameObject.CompareTag("End")) 
            {
                FindObjectOfType<AudioManager>().Play("CatEating");
                SceneManager.LoadScene(3);
            }

        }

        
        }
    
}
