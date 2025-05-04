using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject FirstCol;
    public GameObject CollPic;
    public GameObject CollArrowPic;
    public GameObject CirclePic;
    public GameObject PressBoxPic;
    public GameObject PressBoxArrowPic;
    public GameObject MoveHereCirclePic;
    public GameObject MoveHereArrowPic;
    public GameObject PressFPic;
    public GameObject SecondCol;
    public GameObject PlacePadPic;
    public GameObject PlacePadArrowPic;
    public GameObject PlacePadCirclePic;
    public GameObject JumpHitbox;
    public Rigidbody2D player;
    public GameObject TryAgainPic;
    public GameObject TryJumpPic;
    public GameObject ThirdCol;
    public GameObject JumpDownPic;
    public GameObject PressPadPic;
    public GameObject PressPadArrowPic;
    public GameObject EditmodeText;
    public GameObject Wall01;
    public GameObject EditMoveText;
    public GameObject PressT;
    public GameObject PressTAgain;

    bool EditModeActive = false;
    bool FirstPressF = false;
    bool SecondPressF = false;
    

    public Collectibles Collectibles;
    public playerMovement pm;
    private void Start()
    {
        
        MoveHereCirclePic.SetActive(false);
        MoveHereArrowPic.SetActive(false);
        PressFPic.SetActive(false); 
        PlacePadCirclePic.SetActive(false);
        PlacePadArrowPic.SetActive(false);
        PlacePadPic.SetActive(false);
        TryAgainPic.SetActive(false);
        JumpDownPic.SetActive(false);
        PressBoxPic.SetActive(false);
        PressBoxArrowPic.SetActive(false);
        PressPadPic.SetActive(false);  
        PressPadArrowPic.SetActive(false);
        EditmodeText.SetActive(false);
        Wall01.SetActive(false);
        EditMoveText.SetActive(false);
        PressT.SetActive(false);
        PressTAgain.SetActive(false);
    }

    private void Update()
    {
        if (pm.editMode == true)
        {
            if (EditModeActive) 
            {
                EditmodeText.SetActive(true);
                EditMoveText.SetActive(true);
            } 
            PressBoxPic.SetActive(false);
            PressBoxArrowPic.SetActive(false);
            if (FirstPressF)
            {
                MoveHereCirclePic.SetActive(true);
                MoveHereArrowPic.SetActive(true);
                PressFPic.SetActive(true);
            }
            if (SecondPressF) 
            {
                PlacePadCirclePic.SetActive(true);
                PlacePadArrowPic.SetActive(true);
                PlacePadPic.SetActive(true);
            }

        }

        //if (PressTAgain.activeSelf == true && Input.GetKeyDown(KeyCode.T)) 
        //{ 
        //    PressTAgain.SetActive(false);
        //}


            if (Input.GetKeyDown(KeyCode.F))
        {
            if (Collectibles.colPads == 0)
            { 
                PlacePadCirclePic.SetActive(false);
                PlacePadArrowPic.SetActive(false);
                PlacePadPic.SetActive(false);
            }
            if (Collectibles.colBoxes == 0)
            {
                MoveHereCirclePic.SetActive(false);
                MoveHereArrowPic.SetActive(false);
                PressFPic.SetActive(false);
            }
            
        }
        if (Collectibles.colBoxes == 0)
        {
            FirstPressF = false;
            PressBoxPic.SetActive(false);
            PressBoxArrowPic.SetActive(false);
            EditmodeText.SetActive(false);
            EditMoveText.SetActive(false);
            if (EditModeActive)
            {
                PressT.SetActive(true);
                PressTAgain.SetActive(true);
                EditModeActive = false;
            }

        }
        else if (Collectibles.colBoxes == 1)
        {   
            PressT.SetActive(false);
            PressTAgain.SetActive(false);
        }
        if (Collectibles.colPads == 0)
        {
            SecondPressF = false;
            PressPadPic.SetActive(false);
            PressPadArrowPic.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) { 
        if (collision.gameObject == FirstCol) 
        {
            FirstPressF = true;
            EditModeActive = true;
            CollPic.SetActive(false);
            CollArrowPic.SetActive(false);
            CirclePic.SetActive(false);
            PressBoxPic.SetActive(true);
            PressBoxArrowPic.SetActive(true);
        }
        
        if (collision.gameObject == SecondCol)
        {
            SecondPressF = true;    
            PressPadPic.SetActive(true);
            PressPadArrowPic.SetActive(true);
        }
        
        if (collision.gameObject == ThirdCol) 
        {
            TryJumpPic.SetActive(false);
            TryAgainPic.SetActive(false);
            JumpDownPic.SetActive(true);
            Wall01.SetActive(true);

        }
        if (collision.gameObject == JumpHitbox) 
        {
            if (ThirdCol.activeSelf == true) {
                TryJumpPic.SetActive(false);
                TryAgainPic.SetActive(true);; 
            }
        }
    }
    
}
