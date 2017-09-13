using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //moviment
    public float maxSpeed = 5;

    //jumping
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    //fire
    public Transform gunMuzzle;
    public GameObject missle;
    public float fireRate = 0.5f;
    float nextFire;

    Rigidbody2D rb2d;
    Animator animador;
    bool moveRight = true;
	
	void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
	}

    void Update()
    {
        fire();        
    }

    void FixedUpdate()
    {
        jumpCharacter();
        walkCharacter();
    }

    void fire() {
        if (Input.GetAxisRaw("Fire1")>0 && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            if (moveRight)
                Instantiate(missle,gunMuzzle.position,Quaternion.Euler(Vector3.forward * 0));
            else
                Instantiate(missle, gunMuzzle.position, Quaternion.Euler(Vector3.forward * -180));
        }
    }

    void jumpCharacter() {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            animador.SetBool("isGround", grounded);
            rb2d.AddForce(new Vector2(0, jumpHeight));
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animador.SetBool("isGround", grounded);
        animador.SetFloat("verticalSpeed", rb2d.velocity.y);        
    }

    void walkCharacter() {
        float move = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
        animador.SetFloat("speed", Mathf.Abs(move));

        if (move > 0 && !moveRight)
        {
            flipDirection();
        }
        else if (move < 0 && moveRight)
        {
            flipDirection();
        }
    }

    void flipDirection() {
        moveRight = !moveRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
