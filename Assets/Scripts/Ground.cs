using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

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
    void Update () {
		if(ground.transform.position.x <= -21f)
        {
            Destroy(ground);
        }

        
        if(ground.transform.position.x <= 0 && tileSpawned == false)
        {
            tileSpawned = true;
            newGround = (GameObject)Instantiate(ground);
            
            newGround.transform.Translate( new Vector3(startPoint.transform.position.x,0,0));
        }
		this.transform.Translate(GameMaster.groundMoveSpeed,0,0);
	}
}
