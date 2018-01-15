using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int Deaths = 0;
	public static int Score = 0;
	public static int Coins = 0;

    public static void Save()
    {
        PlayerPrefs.SetInt("Coins", Coins);
        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.SetInt("Deaths", Deaths);
    }


	public static void Scored(int i){
		Score += i;
	}

	public static void loseLife(){
        Deaths++;
	}

	public static void getCoin(){
		Coins++;
		Score += 100;
	}

	public static void clearCoin(){
		Coins = 0;
	}

}
