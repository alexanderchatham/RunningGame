using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalExit : MonoBehaviour {

	public bool a = false;
	public Transform target;
	public GameObject player = null;
	// Update is called once per frame
	void Update () {
			
		if (a && this.gameObject.transform.position.x > (target.position.x - .1f) && this.gameObject.transform.position.x < (target.position.x + .1f))
		{
			a = false;
			player.SetActive (true);
			GameMaster.GetSpeed ();
			Vector3 pos = this.gameObject.transform.position;
			player.GetComponent<Rigidbody2D>().transform.SetPositionAndRotation(pos,Quaternion.Euler (0, 0, 0));
		}
	}
}
