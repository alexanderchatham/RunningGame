using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour {

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
		if(ground.transform.position.x <= endPoint.transform.position.x)
		{
			Destroy(ground);
		}
		this.transform.Translate(GameMaster.groundMoveSpeed,0,0);
	}
}