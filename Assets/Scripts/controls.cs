using System.Collections;
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
    public bool lastlevel = false;
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
    public bool onMovingPlatform;
    public int doublejump;
    public bool doublejumped = true;
    public int numberofjumps = 0;
	bool columnhit = false;
	bool destroyer = false;

    bool editor = false;

    void Start()
    {
#if UNITY_EDITOR
        editor = true;
#endif
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
        doublejump = PlayerPrefs.GetInt("double jump",0);
		if (doublejump == 1)
			print ("doublejump unlocked");
		jumpStart = false;
		tRight = false;
		tLeft = false;
    }

    private void Update()
    {
        if (Starting)
        {
            jump();
            move();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        moving = false;
        if (!dying)
        {
            jump();
            move();
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
        //this code pushes the character back constantly
        if (!lastlevel)
        {
            if (m_Rigidbody.velocity.x <= 0 && !allTheWayLeft && (!tRight || !Input.GetKeyDown(KeyCode.RightArrow)) && !onMovingPlatform) 
            m_Rigidbody.transform.Translate(GameMaster.groundMoveSpeed, 0, 0);
        }
    }

    public bool canDoubleJump()
    {
        if (doublejumped == false && doublejump == 1)
        {
            print("double jump");
            return true;
        }
        else
            return false;
    }

    
	public void jump()
    {
        if (!editor)
        {
            if (((jumpStart && numberofjumps < 1) || (jumpStart && numberofjumps == 1)) && (m_Rigidbody.velocity.y < 1f && OnGround))
            {
                m_Rigidbody.gravityScale = .5f;
                m_Rigidbody.velocity = new Vector2(0, 0);
                if (OnGround == false)
                    doublejumped = true;
                OnGround = false;
                m_Rigidbody.AddForce(m_JumpForce, ForceMode2D.Impulse);
                anim.SetBool("jump", true);
                numberofjumps++;
                if (Starting)
                    startUp();
            }
            if (!jumpStart)
            {
                m_Rigidbody.gravityScale = 2f;
                if (doublejump == 1 && numberofjumps == 1)
                {
                    OnGround = true;
                }
            }
        }
        else
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKey(KeyCode.UpArrow) && numberofjumps < 1)) && ((m_Rigidbody.velocity.y < 1f && OnGround) || canDoubleJump()))
            {
                m_Rigidbody.gravityScale = .5f;
                m_Rigidbody.velocity = new Vector2(0, 0);
                if (OnGround == false)
                    doublejumped = true;
                OnGround = false;
                m_Rigidbody.AddForce(m_JumpForce, ForceMode2D.Impulse);
                anim.SetBool("jump", true);
                numberofjumps++;
                if (Starting)
                    startUp();
            }
            if (Input.GetKeyUp(KeyCode.UpArrow) || !Input.GetKey(KeyCode.UpArrow))
            {
                m_Rigidbody.gravityScale = 2f;
                if (doublejump == 1 && numberofjumps < 2)
                    doublejumped = false;
            }
        }
        //this code makes it so the character doesn't bounce and sticks his landings
        if (OnGround && m_Rigidbody.velocity.y > 0)
        {
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, 0);
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
        //code that makes it so that runs the idle animation
        if (OnGround && moving == false)
        {
            if (!allTheWayLeft)
                anim.SetBool("idle", true);
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

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plank" && OnGround && m_Rigidbody.velocity.y < -0.1f)
        {
            print("walked off");
            m_Rigidbody.velocity = new Vector2(0, m_Rigidbody.velocity.y);
			if (doublejump == 0)
				OnGround = false;
			else
				numberofjumps++;
			}
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
            GameObject.FindGameObjectWithTag("FireballSfx").GetComponent<AudioSource>().Play();
            GameMaster.EndGame ();
			if(!winning)
				PlayerStats.clear ();
			anim.SetBool ("Dead", true);

			destroyer = false;
        }
		if (destroyer)
		{
			Destroy(coll.gameObject.GetComponent<BoxCollider2D> ());
		}
      
        if (coll.gameObject.tag == "fireball")
        {
            print("hit fireball");
            GameObject.FindGameObjectWithTag("FireballSfx").GetComponent<AudioSource>().Play();
            OnGround = false;
            canDash = false;
            jumpStart = false;
            tRight = false;
            tLeft = false;
            dying = true;
            GameMaster.EndGame();
            if (!winning)
                PlayerStats.clear();
            anim.SetBool("trap", true);
			m_Rigidbody.velocity = new Vector2(0, 0);
			m_Rigidbody.AddForce(m_JumpForce, ForceMode2D.Impulse);
            m_Rigidbody.gravityScale = 2;
			Destroy(coll.gameObject.GetComponent<CircleCollider2D> ());
			destroyer = true;
        }
		if (coll.gameObject.tag == "Back")
		{
			print("hit back");
			anim.SetBool ("idle", false);
            allTheWayLeft = true;
		}
        if (coll.gameObject.tag == "Coin")
        {
            if (!dying)
            {
                Coin coin = coll.gameObject.GetComponent<Coin>();
                coin.Collect();
                PlayerStats.getCoin();
            }
        }
        if (coll.gameObject.tag == "Wall")
		{
			m_Rigidbody.gravityScale = 3f;
		}
        if (coll.gameObject.tag == "Plank")
        {
            print("hit plank");
            
                OnGround = true;
                doublejumped = false;
                anim.SetBool("jump", false);
            numberofjumps = 0;
            dashing = false;
            canDash = true;
        }
		if (coll.gameObject.tag == "Column1")
		{
			if (!columnhit)
			{
				print ("hit Column1");
				PlayerStats.Scored (300);
				win ();
				columnhit = true;
			}
		}
		if (coll.gameObject.tag == "Column2")
		{
			if (!columnhit)
			{
				print ("hit Column2");
				PlayerStats.Scored (500);
				win ();
				columnhit = true;
			}
		}
		if (coll.gameObject.tag == "Column3")
		{
			if (!columnhit)
			{
				print ("hit Column3");
				PlayerStats.Scored (1000);
				win ();
				columnhit = true;
			}
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
        Destroy(this.gameObject);
	}

	public void win()
	{
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
		anim.SetBool ("idle", true);
		GameMaster.beatLevel (GameMaster.Level);
		PlayerStats.Save ();

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
        if (other.gameObject.tag == "ring")
        {
            print("hit ring");
            GameObject.FindGameObjectWithTag("RingSfx").GetComponent<AudioSource>().Play();
            PlayerStats.Scored(500);
            Destroy(other.gameObject.GetComponent<BoxCollider2D>());
            other.gameObject.GetComponentInParent<Animator>().SetBool("hit", true);

        }
        if (other.gameObject.tag == "Character Holder")
        {
            print("hit Character Holder");
            onMovingPlatform = true;
        }
		if (other.gameObject.tag == "Portal")
		{
			string ident = other.gameObject.GetComponentInChildren<portal> ().identity;
			GameObject[] exits = GameObject.FindGameObjectsWithTag ("Portal Exit");
			GameObject exit = GameObject.FindGameObjectWithTag ("Portal Exit");
			foreach(GameObject i in exits)
			{
				if (i.GetComponentInChildren<portal> ().identity == ident)
					exit = i;
			}
			exit.GetComponent<PortalExit> ().a = true;
			exit.GetComponent<PortalExit> ().target = this.transform;
			exit.GetComponent<PortalExit> ().player = this.gameObject;
			GameMaster.portalmove (other.gameObject,exit);
			this.gameObject.SetActive (false);
		}
        if (other.gameObject.tag == "Reverse")
        {
            if (!other.gameObject.GetComponent<Reverse>().used)
            {
                Reverse r = other.gameObject.GetComponent<Reverse>();
                other.gameObject.GetComponent<SpriteRenderer>().sprite = r.pressed;
                GameMaster.reverse(r.rewind);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character Holder")
        {
            print("hit Character Holder");
            onMovingPlatform = false;
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
