using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour {

	BoxCollider2D plank;
    bool Disappear = false;
    Color color;
	// Use this for initialization
	void Start () {
		plank = GetComponent<BoxCollider2D> ();
    }

    private void FixedUpdate()
    {
        if (Disappear)
        {
            color = GetComponent<SpriteRenderer>().color;
            color.a = color.a -.015f;
            GetComponent<SpriteRenderer>().color = color;
            if (color.a < .2f && plank)
                Destroy(plank);
            if (color.a == 0)
                Destroy(this.transform.parent.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Disappear = true;
        }
    }

}
