using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour {

	BoxCollider2D plank;
    Animator anim;
	// Use this for initialization
	void Start () {
		plank = GetComponent<BoxCollider2D> ();
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        anim.SetBool("disappear",true);
    }

    public void drop()
    {
        Destroy(plank);
    }

    public void end()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
