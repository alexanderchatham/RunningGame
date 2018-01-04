using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

	private GameObject ground;
	static bool keepAnimating = true;
	private Animator animGround;

    // Update is called once per frame
    private void Awake()
    {
		ground = this.gameObject;
		animGround = GetComponent<Animator> ();
    }

	void Update() 
	{
		if (keepAnimating == false)
			animGround.enabled = false;
	}

	public static void Stop() {


		keepAnimating = false;
	}
}
