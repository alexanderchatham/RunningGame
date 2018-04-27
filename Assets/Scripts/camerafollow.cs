using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour {
    public GameObject playertag;
    public GameObject player;
    public float startPosition = 2.35f; 
    public float rightmostPosition = 19f;
    public float upperbound = 12.64f;
    private bool smooth = true;
    public float smoothSpeed = 0.125f;
    public float lowerbound = 0;
    private Vector3 offset = new Vector3(0,3f,-6.5f);
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void LateUpdate()
	{
		if (player)
		{
			Vector3 desiredPosition = player.transform.position + offset;
			if (desiredPosition.x > startPosition && desiredPosition.x < rightmostPosition && desiredPosition.y < upperbound && desiredPosition.y > lowerbound)
			{
				if (smooth)
					transform.position = Vector3.MoveTowards (transform.position, desiredPosition, smoothSpeed);
				else
					transform.position = desiredPosition;
			} else
			{
				if (desiredPosition.y < upperbound && desiredPosition.y > lowerbound)
				{
					desiredPosition = new Vector3 (this.gameObject.transform.position.x, desiredPosition.y, desiredPosition.z);
					transform.position = Vector3.MoveTowards (transform.position, desiredPosition, smoothSpeed);
				} else if (desiredPosition.x > startPosition && desiredPosition.x < rightmostPosition)
				{
					desiredPosition = new Vector3 (desiredPosition.x, this.gameObject.transform.position.y, desiredPosition.z);
					transform.position = Vector3.MoveTowards (transform.position, desiredPosition, smoothSpeed);
				}
			}
        
		}
	}
}
