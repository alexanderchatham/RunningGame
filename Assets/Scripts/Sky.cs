using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour {
    public GameObject sky1;
    public GameObject sky2;
    public GameObject sky3;
    public GameObject sky4;
    private GameObject startpoint;
    private GameObject endpoint;
    // Use this for initialization
    private void Awake()
    {
        endpoint = (GameObject)Instantiate(sky1);
		endpoint.transform.position = new Vector3 (-21.1f, 1.8f, 0f);
        startpoint = (GameObject)Instantiate(sky4);
    }
	
	// Update is called once per frame
	void Update () {
        positionResetter();

		this.transform.Translate(GameMaster.skyMoveSpeed, 0, 0);
    }

    
    void positionResetter()
    {
        if (sky1.transform.position.x <= endpoint.transform.position.x)
        {
            print("sky1 position is:" + sky1.transform.position);
			sky1.transform.position = new Vector3(startpoint.transform.position.x, sky1.transform.position.y, 0f);
        }
        if (sky2.transform.position.x <= endpoint.transform.position.x)
        {
            print("sky2 position is:" + sky2.transform.position);
			sky2.transform.position = new Vector3(startpoint.transform.position.x,sky1.transform.position.y, 0f);
        }
        if (sky3.transform.position.x <= endpoint.transform.position.x)
        {
            print("sky3 position is:" + sky3.transform.position);
			sky3.transform.position = new Vector3(startpoint.transform.position.x,sky1.transform.position.y, 0f);
        }
    }
}
