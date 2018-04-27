using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public float movespeed = 1f;
	public float movedirection = 1f;
	public bool forwards = true;
	public bool moving = false;
	// Update is called once per frame
	void Update () {
		if (!forwards)
			movedirection = -1f;
		if (forwards)
			movedirection = 1f;
		if (GameObject.FindGameObjectWithTag ("Player"))
			moving = !GameObject.FindGameObjectWithTag ("Player").GetComponent<controls> ().Starting;
		else
			moving = false;
		if(moving)
		this.transform.Translate(movespeed * movedirection,0,0);
	}
	public void Switchdirections(){
		if (forwards == true)
			forwards = false;
		else
			forwards = true;
		this.gameObject.transform.localScale.Set (this.transform.localScale.x * -1f, this.transform.localScale.y, this.transform.localScale.z);
	}
}
