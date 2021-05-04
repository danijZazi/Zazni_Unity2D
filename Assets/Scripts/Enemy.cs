using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    private float startPlace;
    public float moveDistance;
    private bool alive = true;
    private bool injured = false;

    //hitboxes
    public float chestHitBoxRadious;
    public float headHitBoxRadious;
    public float legHitBoxRadious;
    public LayerMask WhatCanKill;
    public Transform ChestHitCheck;
    public Transform HeadHitCheck;
    public Transform LegHitCheck;
    private bool chestHit;
    private bool headHit;
    private bool legHit;

    private Animator anim;

    private void FixedUpdate()
    {
        enemyHit();

        //when enemy is dead
        if (!alive)
        {
            death();

        }

        //cons moving
        if (transform.localScale.x == 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
        }

        //changing move direction 
        if (Mathf.Abs(startPlace - GetComponent<Rigidbody2D>().position.x) > moveDistance)
        {
            changeDirection();
            startPlace = GetComponent<Rigidbody2D>().position.x;
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Alive", alive);
    }

    // Start is called before the first frame update
    void Start()
    {
        startPlace = GetComponent<Rigidbody2D>().position.x;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

     

        
    }


    //turning enemy 
    void changeDirection()
    {
        if(transform.localScale.x == 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
            turnLeft();
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            turnRight();
        }
    }

    public void turnLeft()
    {
        transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
    }
    public void turnRight()
    {
        transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
    }


    //checking hitboxes when bullet hits enemy
    void enemyHit()
    {
        chestHit = Physics2D.OverlapCircle(ChestHitCheck.position, chestHitBoxRadious, WhatCanKill);
        headHit = Physics2D.OverlapCircle(HeadHitCheck.position, headHitBoxRadious, WhatCanKill);
        legHit = Physics2D.OverlapCircle(LegHitCheck.position, legHitBoxRadious, WhatCanKill);
        if (chestHit) alive = false;
        if (headHit) alive = false;
        if (legHit)
        {
            if (injured) alive = false;
            else injured = true;
        }
    }


    //enemy death scenario
    void death()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        moveSpeed = 0;
        anim.Play("enemyDead");
        GetComponent<CapsuleCollider2D>().size = new Vector2((float)0.5, (float)0.2);
    }
}
