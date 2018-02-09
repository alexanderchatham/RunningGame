using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(GameMaster.skyMoveSpeed, 0, 0);
    }
}
