using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

	bool left = false;
	bool right = false;
	Rect jumpRect;
	Rect rightRect;
	Rect leftRect;
	void Start(){
	
		jumpRect = new Rect (0,0,Screen.width/2, Screen.height/2);
		leftRect = new Rect (Screen.width/2,0,Screen.width/4, Screen.height/2);
		rightRect = new Rect (Screen.width/4 * 3f,0,Screen.width/4, Screen.height/2);

	}
	
	// Update is called once per frame
	void Update () {
		foreach (Touch touch in Input.touches)
		{
			if (jumpRect.Contains(touch.position)){
				if (touch.phase == TouchPhase.Began)
				{
					print ("jump");
					controls.jumpStart = true;
				}
				if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
				{
					print ("jump ended");
					controls.jumpStart = false;
				}
				}

			if (rightRect.Contains(touch.position) && !left){
				if (touch.phase == TouchPhase.Began)
				{
					print ("right");
					right = true;

					controls.tRight = true;
				}
				if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
				{
					print ("right ended");
					right = false;
					controls.tRight = false;
				}
			}

			if (leftRect.Contains(touch.position) && right == false){
				if (touch.phase == TouchPhase.Began)
				{
					print ("left");
					left = true;
					controls.tLeft = true;
				}
				if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
				{
					print ("left ended");
					left = false;
					controls.tLeft = false;
				}
			}
			
		
		}
	
	}
}
