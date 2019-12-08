using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    enum PLAYER_STATE { S_WALK, S_IDLE, S_JUMP };
    PLAYER_STATE state;

    public float speed;
    public Vector2 jump;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    AudioSource auds;

    public GameObject mmButton;
    public GameObject resetButton;
    public GameObject expText;
    public GameObject skillsText;
    public GameObject expBackButton;
    public GameObject eduBackButton;
    public GameObject handiBackButton;
    public GameObject skillsBackButton;
    public GameObject skillsNextButton;
    public GameObject eduCoursesButton;

    public Animator animCanvas;
    public Animator animFlashA;
    public Animator animFlashB;

    public AudioSource audsA;
    public AudioClip landing;
    public AudioClip opening;
    public AudioClip impact;

    void Start()
    {
        state = PLAYER_STATE.S_IDLE;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        auds = GetComponent<AudioSource>();
    }

    void Update()
    {
        KeyboardControls();

        switch (state)
        {
            case PLAYER_STATE.S_IDLE:

                anim.Play("idle");

                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
                {
                    state = PLAYER_STATE.S_WALK;
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    state = PLAYER_STATE.S_JUMP;
                    anim.SetTrigger("jump");
                    auds.Play(0);
                }

                break;

            case PLAYER_STATE.S_WALK:

                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
                {
                    anim.SetTrigger("walk");
                }

                if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    state = PLAYER_STATE.S_IDLE;
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    state = PLAYER_STATE.S_JUMP;
                    anim.SetTrigger("jump");
                    auds.Play(0);
                }

                break;

            case PLAYER_STATE.S_JUMP:

                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") && state == PLAYER_STATE.S_JUMP)
        {
            state = PLAYER_STATE.S_IDLE;
            audsA.PlayOneShot(landing);
        }

        if (other.gameObject.CompareTag("Education"))
        {
            animCanvas.Play("edu");
            audsA.PlayOneShot(impact);
            mmButton.SetActive(false);
            resetButton.SetActive(false);
            eduBackButton.SetActive(true);
            eduCoursesButton.SetActive(true);
        }

        if (other.gameObject.CompareTag("Hobbies"))
        {
            animCanvas.Play("handi");
            audsA.PlayOneShot(impact);
            mmButton.SetActive(false);
            resetButton.SetActive(false);
            handiBackButton.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Experience") && Input.GetKey(KeyCode.Space))
        //{
            //animCanvas.Play("exp");
            //animFlashA.Play("flasha");
            //mmButton.SetActive(false);
            //resetButton.SetActive(false);
            //expText.SetActive(false);
            //expBackButton.SetActive(true);
        //}

        if (collision.gameObject.CompareTag("Skills") && Input.GetKey(KeyCode.Space))
        {
            animCanvas.Play("skills");
            animFlashB.Play("flashb");
            audsA.PlayOneShot(opening);
            mmButton.SetActive(false);
            resetButton.SetActive(false);
            skillsText.SetActive(false);
            skillsBackButton.SetActive(true);
            skillsNextButton.SetActive(true);
        }
    }

    void KeyboardControls()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.y <= -7.1f && transform.position.x <= 23f)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            sr.flipX = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.y <= -7.1f && transform.position.x >= -28.5f)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            sr.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y <= -7.1f)
        {
            rb.AddForce(jump, ForceMode2D.Impulse);
        }
    }
}