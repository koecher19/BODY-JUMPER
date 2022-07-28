using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableChangeImage : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite changeToSprite;
    SpriteRenderer spriteRenderer;

    [HideInInspector] public bool collidingWithPlayer;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.collidingWithPlayer = true;
        }

        this.spriteRenderer.sprite = this.changeToSprite;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.collidingWithPlayer = false;
        }

        this.spriteRenderer.sprite = this.defaultSprite;
    }
}
