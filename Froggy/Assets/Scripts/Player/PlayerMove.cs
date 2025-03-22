using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{
    /*public float speed;
    public float jumpSpeed;

    private float dirX;
    private bool jump;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Entrada de datos por variablespara controles
        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }
        if ((Input.GetKey(KeyCode.Space) || jump) && CheckGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    void FixedUpdate()
    {
        //entrada de controles y acciones
        if (Input.GetKey(KeyCode.D) || (dirX >= 1))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            Debug.Log("Derecha");
        }
        else if (Input.GetKey(KeyCode.A) || (dirX <= -1))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            Debug.Log("Izquierda");
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }*/
    public float speed;
    public float maxSpeed;
    public float jumpPower;
    public float jumpPowerPL;
    public float jumpPowerPA;
    public float timeRecuperacion;
    public bool recuperacion;
    public static float health;
    public static float play;

    private bool btmJump;
    private Rigidbody2D rb2d;
    private bool jump;
    private bool jumpL;
    private bool jumpD;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timeRecuperacion = 1f;
        health = 6f;
        play = 1;
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            btmJump = true;
        }
        else
        {
            btmJump = false;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0) || btmJump) && CheckGround.isGrounded) 
        {
            jump = true;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0) || btmJump) && CheckLateralLefth.LateralLefth)
        {
            jumpL = true;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0) || btmJump) && CheckLateralRigth.LateralRight)
        {
            jumpD = true;
        }
        if (CheckGround.isGrounded)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
        if (!CheckGround.isGrounded)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        //float h = Input.GetAxis("Horizontal");
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        /*if (Input.GetKey(KeyCode.D))
        {
            h = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            h = -1;
        }
        else
        {
            h = 0;
        }*/
        Debug.Log(PlayerPrefs.GetInt("LeveClear1"));

        if (play > 0)
        {
            rb2d.AddForce(Vector2.right * speed * h * play);
            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

            if (h == 0 && CheckGround.isGrounded)
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }

            if (jump)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpPower * play, ForceMode2D.Impulse);
                jump = false;
            }

            if (jumpL)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpPowerPL * play, ForceMode2D.Impulse);
                rb2d.AddForce(Vector2.right * jumpPowerPA, ForceMode2D.Impulse);
                jumpL = false;
            }

            if (jumpD)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpPowerPL * play, ForceMode2D.Impulse);
                rb2d.AddForce(Vector2.right * -jumpPowerPA, ForceMode2D.Impulse);
                jumpD = false;
            }

        }

        //animaciones, flips, etc
        if (rb2d.velocity.x > 0 && !CheckLateralLefth.LateralLefth && !CheckLateralRigth.LateralRight)
        {
            FlipPlayer.sp.flipX = false;
        }
        else if (rb2d.velocity.x < 0 && !CheckLateralLefth.LateralLefth && !CheckLateralRigth.LateralRight)
        {
            FlipPlayer.sp.flipX = true;
        }

        if (rb2d.velocity.x == 0 || !CheckGround.isGrounded)
        {
            FlipPlayer.anim.SetBool("Run", false);
        }
        else
        {
            FlipPlayer.anim.SetBool("Run", true);
        }

        if (rb2d.velocity.y > 0 && !CheckGround.isGrounded)
        {
            FlipPlayer.anim.SetBool("Jump", true);
        }
        else
        {
            FlipPlayer.anim.SetBool("Jump", false);
        }
        if (rb2d.velocity.y < 0 && !CheckGround.isGrounded)
        {
            FlipPlayer.anim.SetBool("Fall", true);
        }
        else
        {
            FlipPlayer.anim.SetBool("Fall", false);
        }

        if (rb2d.velocity.y <= 0 || rb2d.velocity.y >= 0  && !CheckGround.isGrounded)
        {
            FlipPlayer.anim.SetBool("Idle", true);
        }
        else
        {
            FlipPlayer.anim.SetBool("Idle", false);
        }
    }

    //Vida y dañooooz
    public void quitarVida(float cantidad)
    {
        if (!recuperacion && health > 0f)
        {
            health -= cantidad;
            StartCoroutine(Recuperarse());
        }
        if (health == 0)
        {
            play = 0;
            StartCoroutine(Morir());
        }
    }
    public void instaKill()
    {
        play = 0;
        StartCoroutine(Morir());
    }

    IEnumerator Recuperarse()
    {
        recuperacion = true;
        yield return new WaitForSeconds(timeRecuperacion);
        recuperacion = false;
    }
    IEnumerator Morir()
    {
        FlipPlayer.anim.SetBool("Daño", true);
        rb2d.gravityScale = 1;
        rb2d.velocity = new Vector2(0, 0);
        rb2d.AddForce(Vector2.up * jumpPower * 0.25f, ForceMode2D.Impulse);
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.6f);
        gameObject.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(4).gameObject.SetActive(true);
        rb2d.velocity = new Vector2(0, 0);
        GameObject.FindGameObjectWithTag("Camara").GetComponent<SceneGeneral>().AnimTransition();
        yield return new WaitForSeconds(1f);
        transform.GetComponent<PlayerRespawn>().playerKill();
        GameObject.FindGameObjectWithTag("Player").gameObject.SetActive(false);
    }
}
