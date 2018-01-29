using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlank : MonoBehaviour {

    public Transform movingPlatform;
    public float smooth;
    public bool moving = false;

    // Update is called once per frame
    void Update () {
        if (moving == true)
        {

        }
        else
        {
            movingPlatform.transform.Translate(GameMaster.groundMoveSpeed, 0, 0);
        }
	}

    public void startMoving()
    {
        moving = true;
        print("starting to move");
    }

    public void stopMoving()
    {
        moving = false;
        print("stopping movement");
    }
    
    
}
