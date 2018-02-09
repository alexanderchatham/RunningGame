using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float angle = 90;
    public float pause = 0;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.gravityScale = 0f;
        rb.transform.eulerAngles = new Vector3(0,0,angle);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (pause > 0)
        {
            pause -= Time.deltaTime;
            return;
        }
        rb.transform.Translate(0, GameMaster.characterMoveSpeed, 0);
	}
}
