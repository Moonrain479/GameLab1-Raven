using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class playerMovement : MonoBehaviour
{

    private Rigidbody2D player;
    private BoxCollider2D col;
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool editMode;

    public bool KnockFromRight;

    private float coyoteTime = 0.01f;
    private float coyoteTimeCounter;

    //private float sprintTime = 3f;
    private float sprintTimeCounter;

    private float speedc = 0;
    private float speed = 8f;

    public bool rightWall;
    public bool leftWall;


    private Animator animator;

    private bool FacingRight = true;

    public RemoveObjects removeObjects;


    [SerializeField] private LayerMask groundJump;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        editMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        float Dx = Input.GetAxisRaw("Horizontal");

        

        animator.SetFloat("Speed", Mathf.Abs(Dx));

        

        if (KBCounter <= 0)
        {
            player.velocity = new Vector2(Dx * speed, player.velocity.y);
        }
        else
        {
            
                if (KnockFromRight == true)
                {
                    player.velocity = new Vector2(-KBForce, 3);
                }
                if (KnockFromRight == false)
                {
                    player.velocity = new Vector2(KBForce, 3);
                }
                KBCounter -= Time.deltaTime;
            
        }

        
        if (editMode == false)
        {
            animator.SetBool("editMode", false);
            player.gravityScale = 3;
            col.isTrigger = false;
            if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
            {
                
                player.velocity = new Vector2(player.velocity.x, 15f);
            }
            
            
        }
        else
        {
            player.gravityScale = 0;
            //col.isTrigger = true;
            animator.SetBool("editMode",true);
            float Dy = Input.GetAxisRaw("Vertical");
            player.velocity = new Vector2(player.velocity.x, Dy * 8f);
            if (FacingRight == false && removeObjects.destroyMode == false) 
            {
                Flip();
            }

        }


        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        //{
         //   sprintTimeCounter = sprintTime;
        //}
        //else 
        if (Dx>0||Dx<0)
        {
            //FindObjectOfType<AudioManager>().Play("CatWalking");
            if (sprintTimeCounter <= 0)
            {
                if (speedc < 1.5f)
                {
                    
                    speedc += Time.deltaTime;
                }
                else 
                {
                    animator.SetBool("Running",true);
                    speed = 11f;
                }            
            } 
            else 
            {
                sprintTimeCounter -= Time.deltaTime;
            }
        }
        else
        {
            //FindObjectOfType<AudioManager>().Stop("CatWalking");
            animator.SetBool("Running",false);
            speed = 8f;
            speedc= 0f;
        }

        

        if (OnGround())
        {
            animator.SetBool("OnGround", true);
            //FindObjectOfType<AudioManager>().Play("Jump");
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            
            animator.SetBool("OnGround", false);
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Dx > 0 && !FacingRight)
        {
            Flip();
        }
        else if (Dx < 0 && FacingRight) { 
            Flip();
        }
    }


    public bool OnGround()
    {
            return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, groundJump);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("RightWall") == true)
        {
            rightWall = true;
        }
        if (collision.gameObject.tag.Equals("LeftWall") == true)
        {
            leftWall = true;
        }
        Debug.Log("set true");
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("RightWall") == true)
        {
            rightWall = false;
        }
        if (collision.gameObject.tag.Equals("LeftWall") == true)
        {
            leftWall = false;
        }
        Debug.Log("set false");
    }
    private void Flip()
    {
            FacingRight = !FacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
    }
    
}
