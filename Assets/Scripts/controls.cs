﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controls : MonoBehaviour {
    
    Vector3 m_JumpForce;
    Vector3 m_DashForce;
    public float jumpStrength = 10f;
    public float dashStrength = 7f;
    Rigidbody2D m_Rigidbody;
    public bool canDash = true;
    public bool dashing = false;
    public bool allTheWayLeft = false;
    public bool OnGround = true;
	public bool moving = false;
	public bool Alive = true;
	public bool Gliding = false;
	public bool Starting = true;
	FlashingText ft;
    DeathPanel DP;
    WinPanel WP;
	UIPanel UIP;
    float m_Result;
	Animator anim;
    SpriteRenderer rend;
	public static bool jumpStart;
	public static bool tRight;
	public static bool tLeft;
	public bool dying = false;
	public bool winning = false;




    void Start()
    {
		Time.timeScale = 0;
        //You get the Rigidbody component you attach to the GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
        rend = GetComponent<SpriteRenderer>();
		ft = FlashingText.ft;
        DP = DeathPanel.instance;
        WP = WinPanel.instance;
		UIP = UIPanel.instance;
        //Initialising the force which is used on GameObject in various ways
        m_JumpForce = new Vector3(0.0f, jumpStrength, 0.0f);
        m_DashForce = new Vector3(dashStrength, 0.0f, 0.0f);
    }


    // Update is called once per frame
    void Update () {
		moving = false;
		if (!dying)
		{
			jump ();
			move ();
		}

		//code for dashing 
		/*
        if (Input.GetKeyDown("x") && canDash == true && !OnGround)
        {
            canDash = false;
            dashing = true;
            allTheWayLeft = false;
            dash();
            
        }
        
        
        if ( canDash == false && dashing == false)
        {
            canDash = true;
        }*/

		//code that makes it so that runs the idle animation
		if (OnGround  && moving  == false)
        {
            if(!allTheWayLeft)
			anim.SetBool ("idle", true);
        }

		//this code makes it so the character doesn't bounce and sticks his landings
        if (OnGround && m_Rigidbody.velocity.y > 0)
        {
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, 0);
        }

		//this code pushes the character back constantly
		if(m_Rigidbody.velocity.x <= 0 && !allTheWayLeft && (!tRight||!Input.GetKeyDown (KeyCode.RightArrow)))
        m_Rigidbody.transform.Translate(GameMaster.groundMoveSpeed, 0, 0);
    }

    
	public void jump()
    {
		if ((Input.GetKeyDown (KeyCode.Space) || jumpStart) && OnGround && m_Rigidbody.velocity.y <= 0)
        {
            m_Rigidbody.gravityScale = .5f;
            m_Rigidbody.AddForce(m_JumpForce, ForceMode2D.Impulse);
            OnGround = false;
            anim.SetBool("jump", true);
            if (Starting)
				startUp ();
        }

		
		if (Input.GetKeyUp (KeyCode.Space) || !jumpStart)
		{
			m_Rigidbody.gravityScale = 2f;
		}
    }




    void move()
    {
		if (Input.GetKey (KeyCode.LeftArrow) || tLeft)
		{
            rend.flipX = true;
            moveLeft();
			
		}
		if (Input.GetKey (KeyCode.RightArrow) || tRight)
		{
            rend.flipX = false;
            moveRight();
			
		}
    }

    public void setLeft()
    {
		tRight = false;
        if (tLeft == false)
            tLeft = true;
        else
            tLeft = false;
    }

    public void setRight()
    {
		tLeft = false;
        if (tRight == false)
            tRight = true;
        else
            tRight = false;
    }

    public void setJump()
    {
        if (jumpStart == false)
            jumpStart = true;
        else
            jumpStart = false;
    }

    public void moveLeft()
    {
        anim.SetBool("idle", false);

        m_Rigidbody.velocity = new Vector3(0, m_Rigidbody.velocity.y);
        m_Rigidbody.transform.Translate(-GameMaster.characterMoveSpeed, 0, 0);
        moving = true;
    }

    public void moveRight()
    {
        if (Starting)
        {
            startUp();
        }
        anim.SetBool("idle", false);
        m_Rigidbody.transform.Translate(GameMaster.characterMoveSpeed, 0, 0);
        moving = true;
        allTheWayLeft = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
			OnGround = false;
			canDash = false;
			jumpStart = false;
			tRight = false;
			tLeft = false;
			dying = true;
			GameMaster.EndGame ();
			if(!winning)
				PlayerStats.clear ();
			anim.SetBool ("Dead", true);

           
        }
		if (coll.gameObject.tag == "Back")
		{
			print("hit back");
			anim.SetBool ("idle", false);
            allTheWayLeft = true;
		}
		if (coll.gameObject.tag == "Wall")
		{
			m_Rigidbody.gravityScale = 3f;
		}
		if (coll.gameObject.tag == "Plank" )
        {
            print("hit plank");
            OnGround = true;

            anim.SetBool("jump", false);
            dashing = false;
            canDash = true;
        }
		if (coll.gameObject.tag == "Column1")
		{
			print("hit Column1");
			PlayerStats.Scored (300);
            win ();
		}
		if (coll.gameObject.tag == "Column2")
		{
			print("hit Column2");
			PlayerStats.Scored (500);
            win ();
		}
		if (coll.gameObject.tag == "Column3")
		{
			print("hit Column3");
			PlayerStats.Scored (1000);
            win ();
		}
     
    }

	public void die()
	{
		Alive = false;
        OnGround = true;
        anim.SetBool("jump", false);
        dashing = false;
        canDash = true;
        jumpStart = false;
        tRight = false;
        tLeft = false;
        GameMaster.EndGame ();
		DP.show();
		UIP.hide ();
	}
	public void win()
	{
		PlayerStats.Save ();
		Ground.Stop ();
		winning = true;
		OnGround = true;
        anim.SetBool("jump", false);
        dashing = false;
		canDash = true;
		jumpStart = false;
		tRight = false;
		tLeft = false;
		GameMaster.EndGame ();
		WP.show();
		UIP.hide ();
		anim.SetBool ("idle", false);

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Gravity" && m_Rigidbody.velocity.y < 0)
        {
            print("hit gravity");
            OnGround = false;
            m_Rigidbody.gravityScale = 1;
        }
        if (other.gameObject.tag == "Coin")
        {
            Coin coin = other.GetComponent<Coin>();
            coin.Collect();
			PlayerStats.getCoin();
        }
    }

    void dash()
    {
        m_Rigidbody.AddForce(m_DashForce, ForceMode2D.Impulse);

		if (Starting)
		{
			startUp ();
		}
    }

	public void startUp()
	{
		GameMaster.GetSpeed ();
		Starting = false;
		ft.hide ();
		Time.timeScale = 1;
		UIP.show ();
	}

	/*public static void touchJump(bool started)
	{
		jumpStart = started;
	}
	public static void touchRight(bool a)
	{
		tRight = a;
	}
	public static void touchLeft(bool a)
	{
		tLeft = a;
	}*/
}

//GLIDING CODE
////////////////////////////////////////////////////////////////////////////////////////
/*if (Input.GetKeyDown (KeyCode.C) && !OnGround)
		{
			m_Rigidbody.velocity = new Vector3 (m_Rigidbody.velocity.x,0);
			Gliding = true;
			if (Starting)
			{
				startUp ();
			}

		}
		if (Gliding)
		{
			m_Rigidbody.velocity = new Vector3 (m_Rigidbody.velocity.x,0);
			m_Rigidbody.transform.Translate(GameMaster.characterMoveSpeed , 0, 0);
		}
      
		if (Input.GetKeyUp(KeyCode.C))
        {
			Gliding = false;
            m_Rigidbody.gravityScale = 2f;
		}*/
