using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour {

	BoxCollider2D plank;
	// Use this for initialization
	void Start () {
		plank = GetComponentInChildren<BoxCollider2D> ();
	}
	
	void OnCollisionEnter2D(){
		
	}
}
