using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public static float groundMoveSpeed = -0.04f;
	public static float skyMoveSpeed = -0.02f;
	public static float characterMoveSpeed = 0.075f;

	public static void EndGame(){
		groundMoveSpeed = 0f;
		skyMoveSpeed = 0f;
		characterMoveSpeed = 0f;
	}


}
