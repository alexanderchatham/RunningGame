﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public const float initialGroundSpeed = -0.06f;
    public const float initialSkySpeed = -0.02f;
    public const float initialCharacterSpeed = 0.2f;


    public static int Level = 0;
	public static int MaxLevel = 30;
    public static float groundMoveSpeed = -0.00f;
	public static float skyMoveSpeed = -0.00f;
	public static float characterMoveSpeed = 0.06f;
    public static bool reversed = false;
	private string currentLevel;
	private string Levelnumber;
	public static int gameSpeed;
    public GameObject Orangedude;
    public GameObject FireGuy;
    public GameObject TreeGuy;
    public GameObject IceGuy;
    public GameObject startingPlayer;
    public GameObject player;
	public static GameObject portalplayer;
	static WinPanel winp;
    public void Start()
    {
        reversed = false;
		winp = WinPanel.instance;
        if (SceneManager.GetActiveScene().name == "Ending Level")
        {
            currentLevel = SceneManager.GetActiveScene().name;
            print(currentLevel);
            gameSpeed = PlayerPrefs.GetInt("speed", 1);
            loadCharacter(PlayerPrefs.GetInt("Character", 0));
        }
        if (SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "Ending Level"){
            currentLevel = SceneManager.GetActiveScene().name;
            Levelnumber = currentLevel.Substring(currentLevel.Length - 2);
            print(Levelnumber);
            Level = int.Parse(Levelnumber);
            PlayerPrefs.SetInt("Current Level", Level);
			gameSpeed = PlayerPrefs.GetInt ("speed", 1);
            loadCharacter(PlayerPrefs.GetInt("Character",0));
        }
        
    }

    public void loadCharacter(int i)
    {
        print("loading character");
        startingPlayer = GameObject.FindGameObjectWithTag("Player");
        Transform startingplace = startingPlayer.transform;
        switch (i)
        {
            case 0:
                player = Instantiate<GameObject>(Orangedude,startingplace);
                print("loading character 0");
                break;
            case 1:
                player = Instantiate<GameObject>(FireGuy, startingplace);
                print("loading character 1");
                break;
            case 2:
                player = Instantiate<GameObject>(TreeGuy, startingplace);
                print("loading character 2");
                break;
            case 3:
                player = Instantiate<GameObject>(IceGuy, startingplace);
                print("loading character 3");
                break;
            default:
                player = Instantiate<GameObject>(Orangedude, startingplace);
                print("loading character default");
                break;
        }
        if(currentLevel == "Ending Level")
            player.GetComponent<controls>().lastlevel = true;
        else
            player.GetComponent<controls>().lastlevel = false;
    }

	public static void GetSpeed(){
		switch (gameSpeed)
		{
			case 0:
				Slow ();
				break;
			case 1:
				Normal ();
				break;
			case 2:
				Fast ();
				break;
			case 3:
				Faster ();
				break;
			default:
				break;
		}

	}

	public static void EndGame(){
		groundMoveSpeed = 0f;
		skyMoveSpeed = 0f;
		characterMoveSpeed = 0f;
	}

    public static void Slow()
    {
        groundMoveSpeed = initialGroundSpeed/1.5f;
        skyMoveSpeed = initialSkySpeed/1.25f;
        characterMoveSpeed = initialCharacterSpeed/1.25f;
    }
    public static void Normal()
    {
        groundMoveSpeed = initialGroundSpeed;
        skyMoveSpeed = initialSkySpeed;
        characterMoveSpeed = initialCharacterSpeed;
    }
    public static void Fast()
    {
        groundMoveSpeed = initialGroundSpeed * 1.5f;
        skyMoveSpeed = initialSkySpeed * 1.25f;
        characterMoveSpeed = initialCharacterSpeed * 1.1f;
    }
    public static void Faster()
    {
        groundMoveSpeed = initialGroundSpeed * 2.25f;
        skyMoveSpeed = initialSkySpeed * 1.75f;
        characterMoveSpeed = initialCharacterSpeed * 1.25f;
    }
    public static void Double()
    {
        if (!reversed)
        {
            groundMoveSpeed = groundMoveSpeed * 5;
            skyMoveSpeed = skyMoveSpeed * 15;
        }
        else
        {
            groundMoveSpeed = groundMoveSpeed * -5;
            skyMoveSpeed = skyMoveSpeed * -15;
        }
    }
	public static void NegDouble()
	{
        if (!reversed)
        {
            groundMoveSpeed = groundMoveSpeed * -5;
            skyMoveSpeed = skyMoveSpeed * -15;
        }
        else
        {
            groundMoveSpeed = groundMoveSpeed * 5;
            skyMoveSpeed = skyMoveSpeed * 15;
        }
    }

 

	public void RestartGame()
	{
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 0;
		GameMaster.EndGame();
        runAd();
    }

	public void RestartGame(bool win)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 0;
        GameMaster.EndGame();
        runAd();
    }

    public void nextLevel()
    {
		
		if (Level < MaxLevel)
		{
			Level++;
            PlayerPrefs.SetInt("Current Level", Level);
            print ("Next Level button. Level is: " + Level);
			SceneManager.LoadScene (Level, LoadSceneMode.Single);
			EndGame ();
			PlayerStats.Save ();
            PlayerStats.clear();
		} else
		{
			print ("At Max Level");
			SceneManager.LoadScene ("Ending Level");
			EndGame ();
			PlayerStats.Save ();
            PlayerStats.clear();
		}
        
        GameMaster.EndGame();
    }
    public void menu()
    {

        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        EndGame();
        Time.timeScale = 1;
        Level = 0;
        PlayerStats.Load();
        runAd();
    }
	public void menu(bool win)
	{
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
		EndGame ();
		Time.timeScale = 1;
        if(Level + 1 <= MaxLevel && win)
            PlayerPrefs.SetInt("Current Level", Level +1);
        Level = 0;
        runAd();
        PlayerStats.clear();
		PlayerStats.Load ();

	}
	public void loadLevel(int i)
	{
		if (i <= MaxLevel)
		{
			Level = i;
            
            SceneManager.LoadScene (i, LoadSceneMode.Single);
			GameMaster.EndGame ();
		}
	}
    public void loadLevel()
    {
            SceneManager.LoadScene
            (
            PlayerPrefs.GetInt("Current Level", 1), LoadSceneMode.Single
            );
            GameMaster.EndGame();
        
    }
    public static void beatLevel(int i)
	{
		if (i <= MaxLevel)
		{
			PlayerPrefs.SetInt("Level " + i, 1);
			print ("coins is " + PlayerStats.Coins);
			winp.setCoins (PlayerStats.Coins);
			print ("score is " + PlayerStats.Score);
			winp.setScore (PlayerStats.Score);
			if (PlayerPrefs.GetInt ("Level " + i + " coins", 0) < PlayerStats.Coins)
			{
				PlayerPrefs.SetInt ("Level " + i + " coins", PlayerStats.Coins);
				winp.setBestCoins (PlayerStats.Coins);
			}
			else
				winp.setBestCoins (PlayerPrefs.GetInt ("Level " + i + " coins", 0));
			if (PlayerPrefs.GetInt ("Level " + i + " score", 0) < PlayerStats.Score)
			{
				PlayerPrefs.SetInt ("Level " + i + " score", PlayerStats.Score);
				winp.setHighscore (PlayerStats.Score);
			} else
				winp.setHighscore (PlayerPrefs.GetInt ("Level " + i + " score", 0));
		}
	}

    public void runAd()
{
        // change no ads default to 0 to enable ads
    if (PlayerPrefs.GetInt("No Ads", 0) == 0) {
        int ad = PlayerPrefs.GetInt("Ad counter", 0);
        if (ad <= 0)
        {
				print ("showing ad");
            ad = 3;
            if (Advertisement.IsReady())
                Advertisement.Show("", new ShowOptions() { resultCallback = HandleAdResult });
        }

        PlayerPrefs.SetInt("Ad counter", ad - 1);
    }
}

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Player Watched ad");
                break;
            case ShowResult.Skipped:
                Debug.Log("Player did not fully watch the ad");
                break;
            case ShowResult.Failed:
                Debug.Log("Player failed to launch the ad ?Internet?");
                break;
        }
    }

	public static void portalmove(GameObject a, GameObject b){
		
	
		Vector3 currentlocation = a.transform.position;
		if (a.transform.position.x < b.transform.position.x)
		{
			Double ();
		} else
		{
			NegDouble ();
		}
	
	}

    public static void Negative()
    {
        groundMoveSpeed = groundMoveSpeed * -1;
        skyMoveSpeed = skyMoveSpeed * -1;
    }
    public static void reverse(bool a)
    {
        if (a)
        {
            Negative();
            reversed = true;
        }
        else
        {
            GetSpeed();
            reversed = false;
        }
    }
}
