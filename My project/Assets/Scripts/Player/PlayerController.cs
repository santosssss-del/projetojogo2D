
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // VARIAVEIS PRIVADAS
    private Rigidbody2D rb;
    private Animator anim;
    private CapsuleCollider2D colliderPlayer;
    private float moveX;

    // VARIAVEIS PUBLICAS
    public float speed;
    public int addJumps;
    public bool isGrounded;
    public float jumpForce;
    public int life;
    public TextMeshProUGUI textLife;
    public string levelName;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveX = Input.GetAxisRaw("Horizontal");
        colliderPlayer = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        textLife.text = life.ToString();

        if (life <= 0)
        {
            this.enabled = false;
            colliderPlayer.enabled = false;
            rb.gravityScale = 0;
            anim.Play("Die", -1);
            SceneManager.LoadScene(levelName);
        }

        if (isGrounded == true)
        {
            addJumps = 1;
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }else{
            if (Input.GetButtonDown("Jump") && addJumps > 0)
            {
                addJumps--;
                Jump();
            }
        }

        Move();
        Attack();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        if (moveX > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            anim.SetBool("IsRun", true);
        }

        if (moveX < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            anim.SetBool("IsRun", true);
        }

        if (moveX == 0)
        {
            anim.SetBool("IsRun", false);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.SetBool("IsJump", true);
        isGrounded = false;
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.Play("Attack", -1);
        }
    }

    public void TomarDano(int dano = 1)
    {
        life = life - dano;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            anim.SetBool("IsJump", false);
        }
    }

}