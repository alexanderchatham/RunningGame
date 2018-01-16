using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int Deaths = 0;
	public static int Score = 0;
	public static int totalScore = 0;
	public static int Coins = 0;
	public static int totalCoins = 0;

    public static void Save()
    {
		print ("Loading old data then Saving!");
		Load ();
		print("Saving!");
        PlayerPrefs.SetInt("Coins", totalCoins + Coins);
		Coins = 0;
        PlayerPrefs.SetInt("Score", totalScore + Score);
		Score = 0;
        PlayerPrefs.SetInt("Deaths", Deaths);
    }

    public static void Load()
    {
		print ("Loading old data");
        totalCoins = PlayerPrefs.GetInt("Coins", 0);
        totalScore = PlayerPrefs.GetInt("Score", 0);
        Deaths = PlayerPrefs.GetInt("Deaths", 0);
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

	public static void clearCoin()
	{
		Coins = 0;
	}
    public static void clearScore()
    {
        Score = 0;
    }
	public static void clear()
	{
		clearCoin ();
		clearScore ();
	}
}
