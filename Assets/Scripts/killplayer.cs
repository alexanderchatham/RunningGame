using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killplayer : MonoBehaviour {

	void  OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Player")
		{
			GameObject.FindGameObjectWithTag ("Player").GetComponent<controls> ().die ();	
		}
	}
}
