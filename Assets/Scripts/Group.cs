using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour {

	public GameObject ground;

	void FixedUpdate () {
		
		ground.transform.Translate(GameMaster.groundMoveSpeed,0,0);
	}
}