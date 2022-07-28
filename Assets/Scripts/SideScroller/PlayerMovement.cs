using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveX;
    public float playerSpeed;
    public float playerRunSpeedMultiplier;
    public float playerJumpPower;
    public AudioSource walkAudio;
    public AudioSource runAudio;
    public AudioSource moveAudio;

    public float speedMultiplier;
    public bool pissUnlocked;
    private bool canMove;
    private bool isGrounded;
    private bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        this.speedMultiplier = 1.0f;
        GetComponent<Animator>().SetFloat("speedMultiplier", 1.0f);
        this.canMove = true;
        this.isGrounded = true;
        this.isWalking = false;
        this.moveAudio = this.walkAudio;
    }


    // Update is called once per frame
    void Update()
    {
        this.playerMove();

        // add piss animation if q-key is presssed
        this.piss();
    }


    void OnCollisionEnter2D(Collision2D theCollision)
    {
        // check if player touches ground:
        if (theCollision.gameObject.name == "Ground")
        {
            this.isGrounded = true;
            
        }
    }
    void OnCollisionExit2D(Collision2D theCollision)
    {
        // check if player touches ground:
        if (theCollision.gameObject.name == "Ground")
        {
            this.isGrounded = false;
        }
    }


    void playerMove()
    {
        // CONTROLS

        // add sprint multiplyer to movement speed if any shift key is pressed:
        if (this.isWalking)
        {
            addSprint();
        }

        // move
        this.moveX = Input.GetAxis("Horizontal") * this.speedMultiplier;

        // jump
        if (Input.GetButtonDown("Jump") && this.isGrounded && this.canMove)
        {
            this.jump();
        }

        // ANIMATIONS + SOUND
        if(moveX != 0 && this.isGrounded)
        {
            // animation
            GetComponent<Animator>().SetBool("isWalking", true);
            // sound
            if (!this.isWalking)
            {
                this.moveAudio.Play();
                this.isWalking = true;
            }
        }
        else
        {
            // animation
            GetComponent<Animator>().SetBool("isWalking", false);
            // sound
            if (this.isWalking)
            {
                this.moveAudio.Stop();
                this.isWalking = false;
            }
        }


        // PLAYER DIRECTIONS
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }

        // walking (PHYSICS)
        if (this.canMove)
        {
            physics();
        }
    }

    void jump()
    {
        // add upwards force (PHYSICS)
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void physics()
    {
        // does physics of movement
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void addSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            this.speedMultiplier = this.playerRunSpeedMultiplier;
            
            // get faster audio clip
            this.moveAudio.Stop();
            this.moveAudio = this.runAudio;
            this.moveAudio.Play();

            GetComponent<Animator>().SetFloat("speedMultiplier", this.playerRunSpeedMultiplier * 0.7f);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            this.speedMultiplier = 1.0f;
               
            // play slower audio clip
            this.moveAudio.Stop();
            this.moveAudio = this.walkAudio;
            this.moveAudio.Play();

            GetComponent<Animator>().SetFloat("speedMultiplier", 1.0f);
        }
    }

    void piss()
    {
        if(Input.GetKeyDown("p") && this.isGrounded && this.pissUnlocked)
        {
            GetComponent<Animator>().SetBool("pee", true);
            this.changeToStinky();
        }
        else
        {
            GetComponent<Animator>().SetBool("pee", false);

        }
    }


    public void disableMovement()
    {
        this.canMove = false;
    }
    public void enableMovement()
    {
        this.canMove = true;
    }

    public void changeToStinky()
    {
        if (!GetComponent<Animator>().GetBool("stinky"))
        {
            GetComponent<Animator>().SetBool("stinky", true);
        }
    }
}
