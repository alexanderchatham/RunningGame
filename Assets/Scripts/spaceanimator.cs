using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceanimator : MonoBehaviour {

    public Sprite a;
    public Sprite b;
    public Sprite c;
    public string selectedsprite = "a";
    public float animationTime = 0;
    public float time = 5f;
	
	// Update is called once per frame
	void Update () {
        animationTime -= .1f;
        if (animationTime <= 0f)
        {
            if (selectedsprite == "a")
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = b;
                selectedsprite = "b";
            }
            else if (selectedsprite == "b")
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = c;
                selectedsprite = "c";
            }
            else if (selectedsprite == "c")
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = a;
                selectedsprite = "a";
            }
            animationTime = time;
        }
	}
}
