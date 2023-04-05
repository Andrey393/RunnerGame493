using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class Hero : MonoBehaviour
{
    [SerializeField] private GameOver GameOver;
    [SerializeField] private Pause Pause;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List <Sprite> healtSprite1;

    [SerializeField] private TMP_Text glassesText;
    [SerializeField] private TMP_Text distanceText;
    [SerializeField] private TMP_Text xGlassesText;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private float moveInput;

    [SerializeField] public static int healt = 1;
    [SerializeField] private int Heal;
    [SerializeField] public static int glasses;

    private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animatorHealt;
    [SerializeField] private Animator animatorPoletBaff;

    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;

    private float jumpTimeCounter;//Сила прыжков в зависимости от удержание клавиша
    [SerializeField] public float jumpTime;
    private bool isJumping;

    public static float baffPolit; //Временный буст (графитация)

    [SerializeField] public static float baffMonet; //Временный буст (двойные монеты)
    [SerializeField] public static int baffMonetCouint;

    private bool heroShel = false;
    private bool heroCtrl = false;
    private BoxCollider2D collider2DSize;

    [SerializeField] private AudioSource jumpSond;

    public float distanceInterval = 100f; // интервал расстояния
    private float lastDistance = 0f;
    int count=0;
   
    private void Start() 
    {
        count = 0;
        healt = 1;
        collider2DSize = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();       
    }
    private void FixedUpdate ( )
    {
        moveInput = Input.GetAxisRaw( "Horizontal" );

        rb.velocity = new Vector2(speed, rb.velocity.y);
        animator.SetFloat ( "Speed",Mathf.Abs( speed) );

        if( baffPolit > 0 )
        {
            baffPolit--;
            animatorPoletBaff.SetFloat ( "TimerPolet", baffPolit );
            rb.gravityScale = 0.5f;
        }
        else
        {
            rb.gravityScale = 2;
            animatorPoletBaff.SetFloat ( "TimerPolet", baffPolit );
        }

        if ( baffMonet > 0 )
        {
            baffMonet--;
           
        }
        else
        {
            baffMonetCouint = 1;
        }
    }

    public void Respawn ( )
    {
        
        rb.position = GenerateLevel.heroSpawnPosition;
        Invoke ( "SetSpeed", 1f );
    }
    void SetSpeed ()
    {
        speed = 5f;
    }

    private void Update ( )
    {
        if ( Input.GetKeyUp ( KeyCode.Escape ) )
        {
            Time.timeScale = 0f;
            Pause.ESC ( );

        }

        Heal = healt;
        if (healt == 0 )
        {
 
            speed = 0;
            GameOver.Setup (  );
        }

        float currentDistance = rb.transform.position.x;//
       
        if ( currentDistance - lastDistance >= distanceInterval )
        {
            lastDistance = currentDistance;
            speed += 0.5f;
        }

        int distant =Convert.ToInt32( rb.transform.position.x);
       
        distanceText.text = distant.ToString();

        spriteRenderer.sprite = healtSprite1 [healt];
        animatorHealt.SetInteger ( "Healt", Mathf.Abs (healt));

        glassesText.text = glasses.ToString();
        xGlassesText.text = baffMonetCouint.ToString() +"x";


        isGrounded = Physics2D.OverlapCircle ( groundCheck.position, checkRadius, whatIsGround );

        if (isGrounded == true )
        {
            animator.SetBool ( "Grounder", isGrounded );                  
        }
        else
        {
            animator.SetBool ( "Grounder", isGrounded );
            animator.SetBool ( "IsJump", false );
        }

        if(isGrounded == true && Input.GetKeyDown ( KeyCode.Space ) && heroCtrl ==false)
        {
            jumpSond.Play ( );
            isJumping = true;          
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;

        }

        if ( Input.GetKey ( KeyCode.Space ) && isJumping == true )
        {
            if(jumpTimeCounter > 0 )
            {
                rb.velocity = Vector2.up *jumpForce;
                jumpTimeCounter -= Time.deltaTime;
                animator.SetBool ( "IsJump", isJumping );

            }
            else
            {
                isJumping = false;
                
            }
        }
        
         if ( Input.GetKeyUp( KeyCode.Space ) )
        {
            isJumping = false;
            
        }
 
        if ( !heroShel ) //Присядь
        {
            heroCtrl = Input.GetKey ( KeyCode.LeftControl );
            animator.SetBool ( "CtrlBool", heroCtrl );
        }


        collider2DSize.offset = new Vector3 ( 0, heroCtrl ? -0.37f : -0.12f );// размер rb.collider 
        collider2DSize.size = new Vector3 ( 1, heroCtrl ? 0.22f : 0.71f );


    }

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        switch ( collision.tag )
        {
            case "Danger":
               if ( healt > 0 )
                 healt--;
                break;
           
            case "Shel":
                heroShel = true;
                break;
           
            case "Platform":
                this.transform.parent = null;
                break;
        }
       
    }
    private void OnTriggerExit2D ( Collider2D collision )
    {
        if ( collision.tag == "Shel" )
        {
            heroShel = false;
            heroCtrl = false;
            animator.SetBool ( "CtrlBool", heroCtrl );
        }
        if ( collision.tag == "Platform")
        {
            this.transform.parent = null;

        }
    }
   

}
