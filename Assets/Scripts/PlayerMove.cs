using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float thrust = 0.4f;
    public bool isGrounded = false;
    public int life = 3;

    public bool facingRight = true;

    private bool doOnce = true;

    public Slider hpBar;

    // Start is called before the first frame update 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0 && doOnce)
        {
            Debug.Log("game over");
            Destroy(gameObject.GetComponent<CapsuleCollider2D>());
            Vector3 myScale = transform.localScale;
            myScale.y *= -1;
            transform.localScale = myScale;

            Camera maincam = this.GetComponentInChildren<Camera>();
            maincam.transform.parent = null;

            doOnce = false;
        }

        float horizontal = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector2(horizontal * thrust, 0.0f));


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0.0f, 7.0f), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Bullet" && life >= 0)
        {
            life -= 1;
            Debug.Log("Life" + life);
            hpBar.value = (life / 3.0f);
            Debug.Log("Life % : " + (life / 3.0f));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }


}
