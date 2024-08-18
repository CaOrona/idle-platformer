using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    bool timerlaunch = false;

    public Rigidbody2D rigidBody;
    public float initialX = 0;
    public int animState = 0;
    bool isInAction = false;
    float timerSlash = 0;
    float timerDash = 10;
    bool isDashing = false;
    public GameObject slash;
    float lastSpeed=0.1f;
    public Manager manager
    {
        get => GetComponentInParent<Manager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        var animator = GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        initialX = rigidBody.position.x;
        animator.Play("Run");
        slash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) Jump();
        if (Input.GetMouseButtonDown(0) && !isInAction)
        {
            Slash();
            timerlaunch = true;
           
        }
        if (Input.GetMouseButtonDown(1)  && !isDashing ) Dash();
        if (timerlaunch) { timerSlash += Time.deltaTime; }
        if (timerSlash > 0.3f)
        {
            timerSlash = 0;
            timerlaunch = false;
            slash.SetActive(false);

        }
        if (gameObject.transform.position.y < -7) SceneManager.LoadScene(0);

    }

    void FixedUpdate()
        {
            rigidBody.velocity += new Vector2(initialX - rigidBody.position.x, 0) / 5;
            var animator = GetComponent<Animator>();
            if (rigidBody.velocity.y < -0.3)
            {
                if (animState != 1) animator.Play("Fall");
                animState = 1;
                isInAction = true;
            }
            if (rigidBody.velocity.y < 0.2 && rigidBody.velocity.y > -0.2 && animState == 1)
            {
                if (animState != 0) animator.Play("Run");
                isInAction = false;
                animState = 0;
            }
        if (isDashing && timerDash !=lastSpeed&& timerDash>0)
        {
            timerDash -= 0.01f;
            manager.speed = timerDash;

        }
        else
        {
            manager.speed = lastSpeed;
            timerDash = 1;
            isDashing = false;
        }


        }

        void Jump(int height = 8)
        {
            if (gameObject.transform.GetChild(0).GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                rigidBody.velocity += Vector2.up * height;
            }
            var animator = GetComponent<Animator>();

            animator.Play("Jump");
            animState = 0;
            isInAction = true;
        }
        void Slash()
        {
            var animator = GetComponent<Animator>();

            animator.Play("Attack1");
            animState = 0;


            slash.SetActive(true);
        }
    void Dash()
    {
        isDashing = true;
        lastSpeed = manager.speed;
        timerDash = manager.speed * 5;
    }

}

