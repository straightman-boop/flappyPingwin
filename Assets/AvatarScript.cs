using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarScript : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    float def_gravityScale = 4.5f;
    bool justOnce = false;

    BoxCollider2D hitbox;
    public float jump;
    [HideInInspector] public bool birdIsAlive = true;

    public GameObject pressToStart;
    public GameObject preview;
    SpriteRenderer spriteRenderer;

    Animator animator;

    AudioSource blub;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        blub = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            LogicScript.logicScript.isGameStart = true;
            myRigidbody.velocity = Vector2.up * jump;
            animator.SetTrigger("Flap");
            blub.Play();

            if (justOnce == false)
            {
                justOnce = true;
                myRigidbody.gravityScale = def_gravityScale;
                pressToStart.SetActive(false);
                preview.SetActive(false);
                spriteRenderer.enabled = true;
            }
        }

        if (transform.position.y > 14 || transform.position.y < -14)
        {
            LogicScript.logicScript.gameOver();
            birdIsAlive = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LogicScript.logicScript.playerLife--;

        if(LogicScript.logicScript.playerLife <= 0)
        {
            hitbox.enabled = false;
            LogicScript.logicScript.gameOver();
            birdIsAlive = false;
        }

    }
}
