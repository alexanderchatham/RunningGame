using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FlashingText : MonoBehaviour {

	GameObject label;
	public GameObject parentCanvas;
	public static FlashingText ft;
	Text labeltext;



	// Use this for initialization
	void Awake(){
		if (ft == null)
			ft = this;
		else
			print ("there is more than one flashing text");
	}


	void Start () {
		label = this.gameObject;
		labeltext = label.GetComponent<Text> ();
		StartCoroutine (flash ());
	}
	
	// Update is called once per frame
	public IEnumerator flash () {
		while (true)
		{
			if (labeltext.IsActive () == true)
				labeltext.enabled = false;
			else
				labeltext.enabled = true;
			yield return new WaitForSeconds (.7f);
		
		}
	}

	public void hide()
	{
		Destroy(parentCanvas);
	}
}
