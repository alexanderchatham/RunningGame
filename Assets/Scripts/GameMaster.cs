using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public const float initialGroundSpeed = -0.06f;
    public const float initialSkySpeed = -0.02f;
    public const float initialCharacterSpeed = 0.2f;


    public static int Level = 0;
	private static int MaxLevel = 6;
    public static float groundMoveSpeed = -0.00f;
	public static float skyMoveSpeed = -0.00f;
	public static float characterMoveSpeed = 0.075f;
	private string currentLevel;
	private string Levelnumber;
	private string gameSpeed;

    public void Start()
    {
        if(SceneManager.GetActiveScene().name != "Menu"){
            currentLevel = SceneManager.GetActiveScene().name;
            Levelnumber = currentLevel.Substring(currentLevel.Length - 2);
            print(Levelnumber);
            Level = int.Parse(Levelnumber);
        }
    }



	public static void EndGame(){
		groundMoveSpeed = 0f;
		skyMoveSpeed = 0f;
		characterMoveSpeed = 0f;
	}

    public static void Slow()
    {
        groundMoveSpeed = initialGroundSpeed/1.25f;
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
        groundMoveSpeed = initialGroundSpeed * 1.25f;
        skyMoveSpeed = initialSkySpeed * 1.25f;
        characterMoveSpeed = initialCharacterSpeed * 1.25f;
    }
    public static void Faster()
    {
        groundMoveSpeed = initialGroundSpeed * 1.75f;
        skyMoveSpeed = initialSkySpeed * 1.75f;
        characterMoveSpeed = initialCharacterSpeed * 1.75f;
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 0;
        GameMaster.EndGame();
    }

    public void nextLevel()
    {
		if (Level < MaxLevel)
		{

			Level++;
			print ("Next Level button. Level is: " + Level);
			SceneManager.LoadScene (Level, LoadSceneMode.Single);
            PlayerStats.clear();
		} else
		{
			print ("At Max Level");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
            PlayerStats.clear();
		}
        
        GameMaster.EndGame();
    }
	public void menu()
	{
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
		GameMaster.EndGame ();
		Level = 0;
		PlayerStats.Load ();
	}
	public void loadLevel(int i)
	{
		if (i <= MaxLevel)
		{
			Level = i;
			SceneManager.LoadScene ("Level " + i, LoadSceneMode.Single);
		}
	}
	public void beatLevel(int i)
	{
		if (i <= MaxLevel)
		{
			PlayerPrefs.SetInt("Level "+i, 1);
			PlayerPrefs.SetInt("Level "+i+" coins",PlayerStats.Coins);
		}
	}
    
}
