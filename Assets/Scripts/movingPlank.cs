using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlank : MonoBehaviour {

    public Transform movingPlatform;
    SpriteRenderer sr;
    public float smooth;
    public bool moving;
    public bool up;
    public bool down;
    Object[] sprites;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Destroy(GetComponent<Animator>());
        
        if (up)
        {
           sprites = Resources.LoadAll("movingplatformup");
            deactivateSprite();
           return;
        }
        if (down)
        {
           sprites = Resources.LoadAll("movingplatformdown");
            deactivateSprite();
            return;
        }
        else
        {
            sprites = Resources.LoadAll("movingplatformright"); 
        }
        deactivateSprite();
    }

    // Update is called once per frame
    void FixedUpdate () {
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
        activateSprite();
    }

    public void stopMoving()
    {
        moving = false;
        print("stopping movement");
        deactivateSprite();
    }


    void activateSprite()
    {


        sr.sprite = (Sprite)sprites[2];
    }

    void deactivateSprite()
    {

        sr.sprite = (Sprite)sprites[1];
    }

}
