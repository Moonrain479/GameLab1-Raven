using UnityEngine;
using UnityEngine.UI;


public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject EditMode;
    public bool destroyMode;

    public GameObject PadPrefab;
    public GameObject OrbPrefabRight;
    public GameObject OrbPrefabLeft;
    public GameObject BoxPrefab;

    public GameObject PadButton;
    public GameObject OrbButton;
    public GameObject BoxButton;

    public GameObject OnGroundText;
    public GameObject OnWallText;
    public GameObject FakePlayer;

    public Collectibles Collectibles;
    public RemoveObjects removeObjects;
    
    //private int ownedPads = 0;
    //private int ownedOrbs = 0;
    //private int ownedBoxes = 0;

    private bool selectedPad = false;
    private bool selectedOrb = false;
    private bool selectedBox = false;

    public float x;
    public float y;

    public playerMovement playerMovement;

    public Rigidbody2D player;

    [SerializeField] Text pad;
    [SerializeField] Text orb;
    [SerializeField] Text box;

    //public SpriteRenderer spriteRenderer;
    //public Sprite Box;
    //public Sprite Cat;
    //public Sprite Pad;
    //public Sprite Orb;
    //public Sprite OrbLeft;

    public Animator animator;

    void Start()
    {
        destroyMode = removeObjects.destroyMode;
        EditMode.SetActive(false);
        OnGroundText.SetActive(false);
        OnWallText.SetActive(false);
        FakePlayer.SetActive(false);    
        x = player.position.x;
        y = player.position.y;
        //player = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        pad.text = "" + Collectibles.colPads;
        orb.text = "" + Collectibles.colOrbs;
        box.text = "" + Collectibles.colBoxes;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerMovement.editMode == true)
            {
                destroyMode = false;
                FakePlayer.SetActive(false);
                OnGroundText.SetActive(false);
                player.position = new Vector2(x, y);
                playerMovement.editMode = false;
                EditMode.SetActive(false);
            }
        }

        if (playerMovement.editMode && selectedOrb)
        {
            if (playerMovement.leftWall)
            {
                CatSprite();
                OrbLeftSprite();
            }
            else if (playerMovement.rightWall) 
            {
                CatSprite();
                OrbSprite();
            }
        }

        if (playerMovement.editMode == false)
        {
            CatSprite();
            destroyMode = false;
            x = player.position.x;
            y = player.position.y;
            OnWallText.SetActive(false);
        }

        

        if (playerMovement.editMode == true)
        {
            if (player.position.x > x + 15)
                player.position = new Vector2(x + 15, player.position.y); ;

            if (player.position.x < x - 15)
                player.position = new Vector2(x - 15, player.position.y);

            if (player.position.y > y + 15)
                player.position = new Vector2(player.position.x, y + 15); ;

            if (player.position.y < y - 15)
                player.position = new Vector2(player.position.x, y - 15);

            if (Input.GetKeyDown(KeyCode.F))
            {                
                destroyMode = false;
                GameObject g;
                if (selectedPad)
                {
                    if (playerMovement.OnGround())
                    {
                        OnGroundText.SetActive(false);
                        g = (GameObject)GameObject.Instantiate(PadPrefab);
                        selectedPad = false;
                        Collectibles.colPads = Collectibles.colPads - 1;
                        Transform t = g.transform;
                        t.position = new Vector2(player.position.x, player.position.y);
                        player.position = new Vector2(x, y);
                        playerMovement.editMode = false;
                        FakePlayer.SetActive(false);
                        EditMode.SetActive(false);
                        
                    }
                    else 
                    {
                        OnGroundText.SetActive(true);
                    }
                }
                else if (selectedOrb)
                {
                    if (playerMovement.rightWall == true) {
                        OnWallText.SetActive(false);
                        g = (GameObject)GameObject.Instantiate(OrbPrefabRight);
                        selectedOrb = false;
                        Collectibles.colOrbs = Collectibles.colOrbs - 1;
                        Transform t = g.transform;
                        t.position = new Vector2(player.position.x, player.position.y );
                        player.position = new Vector2(x, y);
                        playerMovement.editMode = false;
                        FakePlayer.SetActive(false);
                        EditMode.SetActive(false);
                    }
                    if (playerMovement.leftWall == true)
                    {
                        OnWallText.SetActive(false);
                        g = (GameObject)GameObject.Instantiate(OrbPrefabLeft);
                        selectedOrb = false;
                        Collectibles.colOrbs = Collectibles.colOrbs - 1; 
                        Transform t = g.transform;
                        t.position = new Vector2(player.position.x, player.position.y);
                        player.position = new Vector2(x, y);
                        playerMovement.editMode = false;
                        FakePlayer.SetActive(false);
                        EditMode.SetActive(false);
                    }
                    else
                    {
                        OnWallText.SetActive(true);
                    }

                }
                else if (selectedBox)
                {
                    if (playerMovement.OnGround())
                    {
                        OnGroundText.SetActive(false);
                        g = (GameObject)GameObject.Instantiate(BoxPrefab);
                        selectedBox = false;
                        Collectibles.colBoxes = Collectibles.colBoxes - 1;
                        Transform t = g.transform;
                        t.position = new Vector2(player.position.x, player.position.y);
                        player.position = new Vector2(x, y);
                        playerMovement.editMode = false;
                        FakePlayer.SetActive(false);
                        EditMode.SetActive(false);
                    }
                    else 
                    {
                        OnGroundText.SetActive(true);
                    }
                    
                }
                
            }
        }
    }

    public void OnPadButton()
        {
        selectedOrb = false;
        selectedBox = false;
        CatSprite();
        PadSprite();
        destroyMode = false;
        if (Collectibles.colPads != 0)
            {
            if (playerMovement.editMode == false)
            {
                x = player.position.x;
                y = player.position.y;
            }
            EditMode.SetActive(true);
            selectedPad = true;

            playerMovement.editMode = true;
            FakePlayer.SetActive(true);
            Transform Fp = FakePlayer.transform;
            Fp.position = new Vector2(x, y);
            //ResumeGame();
        }
            else 
            {
                Debug.Log("Nichts");
            }
        }

        public void OnOrbButton()
        {
        selectedPad = false;
        selectedBox = false;
        CatSprite();
        OrbSprite();
        destroyMode = false;
        if (playerMovement.editMode == false)
        {
            x = player.position.x;
            y = player.position.y;
        }
        if (Collectibles.colOrbs != 0)
            {
                EditMode.SetActive(true);
                selectedOrb = true;
                playerMovement.editMode = true;
                FakePlayer.SetActive(true);
                Transform Fp = FakePlayer.transform;
                Fp.position = new Vector2(x, y);
            //ResumeGame();
        }
            else
            {
                Debug.Log("Nichts");
            }
        }

        public void OnBoxButton()
        {
        selectedOrb = false;
        selectedPad = false;
        CatSprite();
        BoxSprite();
        destroyMode = false;
        if (playerMovement.editMode == false)
        {
            x = player.position.x;
            y = player.position.y;
        }
        if (Collectibles.colBoxes != 0)
            {
                EditMode.SetActive(true);
                selectedBox = true;
                playerMovement.editMode = true;
            FakePlayer.SetActive(true);
            Transform Fp = FakePlayer.transform;
            Fp.position = new Vector2(x, y);
            //ResumeGame();
        }
            else
            {
                Debug.Log("Nichts");
            }
        
    }

    public void BoxSprite()
    {
        animator.SetBool("Box", true);
    }
    public void CatSprite()
    {
        animator.SetBool("Box", false);
        animator.SetBool("OrbRight", false);
        animator.SetBool("Pad", false);
        animator.SetBool("OrbLeft", false);
    }
    public void PadSprite()
    {
        animator.SetBool("Pad", true);
    }
    public void OrbSprite()
    {
        animator.SetBool("OrbRight", true);
    }
    public void OrbLeftSprite()
    {
        animator.SetBool("OrbLeft", true);
    }
}
