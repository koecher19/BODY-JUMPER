using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    public bool movementEnabled;
    public float playerSpeed;
    public float playerSprintSpeed;
    float speedMultiplyer;
    public bool isWalkingX;
    public bool isWalkingY;
    public bool isWalkingAny;

    private float moveX;
    private float moveY;
    Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.audioSource = GetComponent<AudioSource>();

        this.speedMultiplyer = this.playerSpeed * 0.25f;
        animator.SetFloat("speedMultiplyer", this.speedMultiplyer);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (this.movementEnabled)
        {
            // get movement
            this.moveX = Input.GetAxis("Horizontal");
            this.moveY = Input.GetAxis("Vertical");

            // PHYSICS:
            Physics();
        }


        // ANIMATIONS:
        if (this.moveX != 0)
        {
            this.animator.SetBool("isWalkingX", true);

        }
        else
        {
            this.animator.SetBool("isWalkingX", false);
        }

        if (this.moveY < 0)
        {
            this.animator.SetBool("isWalkingYDown", true);
        }
        else
        {
            this.animator.SetBool("isWalkingYDown", false);
        }

        if (this.moveY > 0)
        {
            this.animator.SetBool("isWalkingYUp", true);
        }
        else
        {
            this.animator.SetBool("isWalkingYUp", false);
        }

        // WALKING SOUND
        if((this.moveY != 0 || this.moveX !=0) && this.isWalkingAny == false)
        {
            this.isWalkingAny = true;
            this.audioSource.Play();
        }
        else if((this.moveY == 0 && this.moveX == 0) && this.isWalkingAny == true)
        {
            this.isWalkingAny = false;
            this.audioSource.Stop();
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
    }
    /*
    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            this.speedMultiplier = 1.5;

            GetComponent<Animator>().SetFloat("speedMultiplier", this.playerRunSpeedMultiplier * 0.7f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            this.speedMultiplier = 1.0f;

            GetComponent<Animator>().SetFloat("speedMultiplier", 1.0f);
        }
    }
    */

    void Physics()
    {
        // does physics of movement
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.moveX * this.playerSpeed, this.moveY * this.playerSpeed);
    }

    /*
    void SetSpeed(string mode)
    {
        switch (mode)
        {
            case "walk":
                break;
            case "sprint":
                break;
            default:
                Debug.Log("TopDownPlayerMovement -> SetSpeed -> input string must be walk or sprint");
        }
    }
    */
}
