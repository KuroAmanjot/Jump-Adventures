using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 



public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private BoxCollider2D capCollider;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float movementSpeed;
    [SerializeField]private float jumpForce;
   // private bool isJumping;
    private float moveHorizontal;
    //private float moveVertical;
    private float jumpDelay;
    public float jumpTimeCompare;


    // Start is called before the first frame update

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        capCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {


        /*rb2D = GetComponent<Rigidbody2D>();
        movementSpeed = 3f;
        jumpForce = 30f;
        isJumping = false;
        jumpDelay = .1f; 
        */ 

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal"); 
        //moveVertical = Input.GetAxisRaw("Vertical");
        isGrounded();

        JumpTimer.timer = jumpDelay; 
    }

    void FixedUpdate()
    {


        if (moveHorizontal > 0.1f|| moveHorizontal< -0.1f  )
        {
            rb2D.AddForce(new Vector2(moveHorizontal*movementSpeed , 0f ), ForceMode2D.Impulse);
        }
        if ( isGrounded() && (jumpDelay > jumpTimeCompare ) )
        {
            Jump();
            print(" jump ");
        }
       
        else
        {

            jumpDelay += Time.deltaTime;

        }


    }

    private void Jump()
    {
        rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        jumpDelay = 0f;
        
    }

    private bool isGrounded()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(capCollider.bounds.center, capCollider.bounds.size, 0 , Vector2.down, 0.1f, groundLayer);
    
        

        return raycast.collider != null;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "deathzone")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }


    }


}
