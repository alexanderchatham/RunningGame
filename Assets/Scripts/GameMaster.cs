using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public const float initialGroundSpeed = -0.04f;
    public const float initialSkySpeed = -0.02f;
    public const float initialCharacterSpeed = 0.075f;


    public static float groundMoveSpeed = -0.04f;
	public static float skyMoveSpeed = -0.02f;
	public static float characterMoveSpeed = 0.075f;

	public static void EndGame(){
		groundMoveSpeed = 0f;
		skyMoveSpeed = 0f;
		characterMoveSpeed = 0f;
	}

    public static void Slow()
    {
        groundMoveSpeed = initialGroundSpeed/1.5f;
        skyMoveSpeed = initialSkySpeed/1.5f;
        characterMoveSpeed = initialCharacterSpeed/1.5f;
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
        skyMoveSpeed = initialSkySpeed * 1.5f;
        characterMoveSpeed = initialCharacterSpeed * 1.5f;
    }
    public static void Faster()
    {
        groundMoveSpeed = initialGroundSpeed * 2f;
        skyMoveSpeed = initialSkySpeed * 2f;
        characterMoveSpeed = initialCharacterSpeed * 2f;
    }
}
