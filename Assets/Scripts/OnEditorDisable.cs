using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEditorDisable : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
#if UNITY_EDITOR
        print("Destroying UI");
        Destroy(this.gameObject);
#endif
    }
	

}
