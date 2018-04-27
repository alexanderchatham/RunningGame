using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	
	void  OnCollisionExit2D(Collision2D collision){
		this.gameObject.transform.position.Set (this.gameObject.transform.position.x * -1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
		this.gameObject.GetComponentInParent<enemy> ().Switchdirections ();
	}
}
