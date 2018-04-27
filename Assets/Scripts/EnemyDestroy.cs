using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour {


	void  OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Player")
		{
			GameObject.FindGameObjectWithTag ("Player").GetComponent<controls> ().boostJump();
			PlayerStats.Scored (500);
			Destroy (this.gameObject.transform.parent.gameObject);		
		}
	}
}
