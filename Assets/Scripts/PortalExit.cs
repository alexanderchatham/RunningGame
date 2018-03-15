using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalExit : MonoBehaviour {

	public bool a = false;
	public Transform target;
	public GameObject player = null;
	// Update is called once per frame
	void Update () {
			
		if (a && this.gameObject.transform.position.x > (target.position.x - .5f) && this.gameObject.transform.position.x < (target.position.x + .5f))
		{
			a = false;
			player.SetActive (true);
			GameMaster.GetSpeed ();
			Vector3 pos = this.gameObject.transform.position;
			player.GetComponent<Rigidbody2D>().transform.SetPositionAndRotation(new Vector3(pos.x,pos.y, -1f),Quaternion.Euler (0, 0, 0));
		}
	}
}
