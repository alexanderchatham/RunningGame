using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCharacter : MonoBehaviour {

    public movingPlank mP;
    controls c;

    private void Start()
    {
        mP = GetComponentInParent<movingPlank>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("hit moving platform");
        other.transform.parent = gameObject.transform;
        mP.startMoving();
        if(other.tag == "Player")
        {
            c = other.GetComponent<controls>();
            c.onMovingPlatform = true;
            print(c.onMovingPlatform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.parent = null;
        if (other.tag == "Player")
        {
            c = other.GetComponent<controls>();
            c.onMovingPlatform = false;
            mP.stopMoving();
            print(c.onMovingPlatform);
        }
    }
}
