using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlank : MonoBehaviour {

    public Transform movingPlatform;
    public float smooth;
    public bool moving = false;
	public bool up = false;
	public bool down = false;

    // Update is called once per frame
    void Update () {
        if (moving == true)
        {
			if (up)
			{
				movingPlatform.transform.Translate (0, -GameMaster.groundMoveSpeed, 0);
				movingPlatform.transform.Translate(GameMaster.groundMoveSpeed, 0, 0);
			}
			if (down)
			{
				movingPlatform.transform.Translate (0, GameMaster.groundMoveSpeed, 0);
				movingPlatform.transform.Translate(GameMaster.groundMoveSpeed, 0, 0);
			}
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
