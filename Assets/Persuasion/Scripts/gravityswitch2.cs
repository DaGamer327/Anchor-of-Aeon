using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gravityswitch2 : MonoBehaviour
{
    Rigidbody2D rb;
    public int sidespeed;
    public int jumpheight;

    public int direction;

    bool isGrounded;
    bool isNearWall;
    bool canwalljump;
    public float cooldown;

    public float sideforce;

    public int doublejump = 2;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform wallCheck;

    private NPC_Controller npc;

    SpriteRenderer spriteRenderer;

    public FadingOut fadetrigger;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        direction = 1;
        canwalljump = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (!inDialogue())
        {
            if (Input.GetKeyDown("s") && isGrounded)
            {

                transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
                rb.AddForce(Vector2.right * sidespeed * direction);


                /*
                if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
                    rb.velocity = new Vector2(sidespeed, 0);

                }
                */

            }


            if (Input.GetKeyUp("s") && isGrounded)
            {

                transform.localScale = new Vector3(transform.localScale.x, 2f, transform.localScale.z);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }

    }


    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
            doublejump = 1;
        }
        else
        {
            isGrounded = false;
        }

        if (Physics2D.Linecast(transform.position, wallCheck.position, 1 << LayerMask.NameToLayer("Wall")))
        {
            isNearWall = true;
        }
        else
        {
            isNearWall = false;
        }


        Controls();


    }

    void Controls()
    {
        if (!inDialogue())
        {

            if (Input.GetKey("d"))
            {
                rb.velocity = new Vector2(sidespeed, rb.velocity.y);
                transform.localScale = new Vector3(2f, 2f, 1f);
                direction = 1;
            }
            else if (Input.GetKey("a"))
            {
                rb.velocity = new Vector2(-sidespeed, rb.velocity.y);
                transform.localScale = new Vector3(-2f, 2f, 1f);
                direction = -1;

            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpheight);


            }

            if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
            {
                if (doublejump > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpheight);
                    doublejump--;
                }



            }

            if (canwalljump)
            {
                rb.velocity = new Vector2(sidespeed * sideforce * direction, jumpheight);
                doublejump = 1;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isNearWall && !isGrounded)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, 2f, 1f);
                canwalljump = true;
                Invoke("WallJumpFalse", cooldown);
            }

            if (!isGrounded)
            {
                transform.localScale = new Vector3(transform.localScale.x, 2f, transform.localScale.z);
            }


        }

    }

    void WallJumpFalse()
    {

        canwalljump = false;
    }

    private bool inDialogue()
    {
        if (npc != null)
            return npc.DialougeActivate();
        else
            return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            npc = collision.gameObject.GetComponent<NPC_Controller>();

            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.gameObject.GetComponent<NPC_Controller>().ActivateDialogue();

            }
        }

        if (collision.gameObject.tag == "Next")
        {
            fadetrigger.FadeIn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        npc = null;
    }
}



