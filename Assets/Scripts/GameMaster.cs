using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public const float initialGroundSpeed = -0.06f;
    public const float initialSkySpeed = -0.02f;
    public const float initialCharacterSpeed = 0.1f;


    public static int Level = 1;
    public static float groundMoveSpeed = -0.00f;
	public static float skyMoveSpeed = -0.00f;
	public static float characterMoveSpeed = 0.075f;



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
        Level++;
        print("Next Level button. Level is: "+ Level);
        if(Level < 4)
            SceneManager.LoadScene("Level " + Level, LoadSceneMode.Single);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        GameMaster.EndGame();
    }

    
}
