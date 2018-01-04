using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour {
    
    Vector3 m_JumpForce;
    Vector3 m_DashForce;
    public float jumpStrength = 5f;
    public float dashStrength = 7f;
    Rigidbody2D m_Rigidbody;
    Vector3 startingPosition;
    public bool canDash = true;
    public bool dashing = false;
    public bool allTheWayLeft = true;
    public bool OnGround = true;
	public bool moving = false;
	public bool Alive = true;
	public bool Gliding = false;
    float m_Result;
	Animator anim;



    void Start()
    {
        //You get the Rigidbody component you attach to the GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
        startingPosition = this.transform.position;
        //Initialising the force which is used on GameObject in various ways
        m_JumpForce = new Vector3(0.0f, jumpStrength, 0.0f);
        m_DashForce = new Vector3(dashStrength, 0.0f, 0.0f);
    }


    // Update is called once per frame
    void Update () {
		moving = false;
        jump();
        move();
        if (Input.GetKeyDown("x") && canDash == true && !OnGround)
        {
            canDash = false;
            dashing = true;
            allTheWayLeft = false;
            dash();
            
        }
        
        
        if (this.transform.position.x <= startingPosition.x && canDash == false && dashing == false)
        {
            m_Rigidbody.MovePosition(new Vector2(startingPosition.x, this.transform.position.y));
            m_Rigidbody.velocity = new Vector3(0, 0);
            canDash = true;
            allTheWayLeft = true;
        }

		if (OnGround && this.transform.position.x > startingPosition.x && moving  == false)
        {
			anim.SetBool ("idle", true);
        }
        if (OnGround && m_Rigidbody.velocity.y > 0)
        {
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, 0);
        }

        if(m_Rigidbody.velocity.x <= 0)
        m_Rigidbody.transform.Translate(GameMaster.groundMoveSpeed, 0, 0);
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            m_Rigidbody.gravityScale = .5f;
            m_Rigidbody.AddForce(m_JumpForce, ForceMode2D.Impulse);
            OnGround = false;
        }

		if (Input.GetKeyDown (KeyCode.C) && !OnGround)
		{
			m_Rigidbody.velocity = new Vector3 (m_Rigidbody.velocity.x,0);
			Gliding = true;

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
        }
		if (Input.GetKeyUp(KeyCode.Space))
		{
			m_Rigidbody.gravityScale = 2f;
		}
    }

    void move()
    {
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			anim.SetBool ("idle", false);
			m_Rigidbody.velocity = new Vector3(0,m_Rigidbody.velocity.y);
			m_Rigidbody.transform.Translate (-GameMaster.characterMoveSpeed, 0, 0);
			moving = true;
		}
		if (Input.GetKey (KeyCode.RightArrow))
		{
			anim.SetBool ("idle", false);
			m_Rigidbody.transform.Translate (GameMaster.characterMoveSpeed, 0, 0);
			moving = true;
		}
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
			OnGround = false;
			canDash = false;
			anim.SetBool ("Dead", true);
			Alive = false;
			GameMaster.EndGame ();
			Ground.Stop ();
           
        }
		if (coll.gameObject.tag == "Back")
		{
			print("hit back");
			anim.SetBool ("idle", false);
		}
        if (coll.gameObject.tag == "Plank")
        {
            print("hit plank");
            OnGround = true;
            dashing = false;
            canDash = true;
        }

     
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
        }
    }

    void dash()
    {
        m_Rigidbody.AddForce(m_DashForce, ForceMode2D.Impulse);
        
    }
}
