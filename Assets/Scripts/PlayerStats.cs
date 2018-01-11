using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int Lives = 3;
	public static int Score = 0;
	public static int Coins = 0;




	public static void Scored(int i){
		Score += i;
	}

	public static void loseLife(){
		if (Lives > 1)
			Lives--;
	}

	public static void getCoin(){
		Coins++;
		Score += 100;
	}

}
