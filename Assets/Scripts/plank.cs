using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plank : MonoBehaviour {

    public GameObject ground;
    private GameObject startPoint;
    private GameObject endPoint;
    private bool tileSpawned;
    private GameObject newGround;

    // Update is called once per frame
    private void Start()
    {

        endPoint = GameObject.FindGameObjectWithTag("End");

        startPoint = GameObject.FindGameObjectWithTag("Start");

 
        //coroutines for movement
    }
    void FixedUpdate () {
	
		this.transform.Translate(GameMaster.groundMoveSpeed,0,0);
	}
}
