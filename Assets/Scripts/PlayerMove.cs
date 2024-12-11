using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float thrust = 0.4f;
    public bool isGrounded = false;
    private float life = 1.0f;
    public float infectionRate = 0.01f;
    public bool isInfected = false;

    public GameObject inGameMenu;
    public TMP_Text gameOverText;

    public bool facingRight = true;

    private bool doOnce = true;

    private Animator playerAnimator;

    public Slider hpBar;

    // Start is called before the first frame update 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();
        gameOverText.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            inGameMenu.SetActive(true);
        }
        //if the player is infected, drain health at a rate of infectionRate per second
        if (isInfected && life >= 0)
        {
            Debug.Log("Due to infection, health is decreasing from " + life + " to " + (life - infectionRate * Time.deltaTime));
            life -= infectionRate * Time.deltaTime;
            hpBar.value = life;
        }


        if (life <= 0 && doOnce)
        {
            PlayerDeath();
        }

        float horizontal = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector2(horizontal * thrust, 0.0f));

        if (Mathf.Abs(horizontal) > 0.1f)
        {
            playerAnimator.SetBool("Run", true);
        }
        else
        {
            playerAnimator.SetBool("Run", false);
        }

        if (horizontal > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (horizontal < 0 && facingRight)
        {
            FlipCharacter();
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerAnimator.SetBool("Jump", true);
            rb.AddForce(new Vector2(0.0f, 7.0f), ForceMode2D.Impulse);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("Infected!");
            isInfected = true;
        }

        if(collision.gameObject.tag == "HostileProjectile")
        {
            life -= 0.05f;
            //isInfected = true;
            Destroy(collision.gameObject);
            hpBar.value = life;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sink")
        {
            Debug.Log("Cured!");
            isInfected = false;
        }

        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Winner!");
            isInfected = false;
            if (gameOverText != null)
            {
                gameOverText.text = "You Made It.";
                gameOverText.color = Color.blue;
                gameOverText.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("gameOverText is not assigned!");
            }
        }

        if (collision.gameObject.tag == "KillBox")
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        Debug.Log("game over");

        gameOverText.text = "You Lose!!!!!!!";
        gameOverText.color = Color.red;
        gameOverText.gameObject.SetActive(true);

        Destroy(gameObject.GetComponent<CapsuleCollider2D>());
        Vector3 myScale = transform.localScale;
        myScale.y *= -1;
        transform.localScale = myScale;

        Camera maincam = this.GetComponentInChildren<Camera>();
        maincam.transform.parent = null;

        doOnce = false;
    }
}
