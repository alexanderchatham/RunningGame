using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {
    Rigidbody2D rb;
    SpriteRenderer sr;
    public Vector2 dir = new Vector2(0, .5f);
    private float startingHeight;

    public float jumpStrength = 10f;
    Vector3 m_JumpForce;
    bool killedPlayer = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        startingHeight = rb.position.y;
        m_JumpForce = new Vector3(0.0f, jumpStrength, 0.0f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (rb.position.y < startingHeight && rb.velocity.y<0 && killedPlayer == false)
            bounce();
        if (rb.velocity.y < 0)
            sr.flipY = true;
	}
    void bounce()
    {
        rb.velocity = new Vector2 (0,0); 
        rb.AddForce(m_JumpForce, ForceMode2D.Impulse);
        sr.flipY = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity.Set(0,0);
        rb.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        
    }
}
