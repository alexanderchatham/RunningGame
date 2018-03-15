using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour {

	
	// Update is called  
	float x;
	public string identity = "a";
	public float spinspeed = 40;
	public bool spin = true;
	public bool reverse = false;

	void Update () {
		if (spin)
		{
			if (!reverse)
				x += Time.deltaTime * spinspeed;
			else
				x -= Time.deltaTime * spinspeed;
			transform.rotation = Quaternion.Euler (0, 0, x);

		}
	}
}
