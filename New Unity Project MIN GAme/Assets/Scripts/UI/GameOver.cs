using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{
	// Game Over Screen:
	public GameObject gameOverScreen = null;
	public GameObject waveManger = null;

	// Time Passed Between The Death Of The Player And Appearance Of The Game Over Screen:
	public float delayBeforeAppearing = 1.0f;
	public float timer = 0.0f;

	// Use This For Initialization:
	void Start ()
	{
		waveManger = GameObject.Find("WaveManager");
		waveManger.SetActive (true);
	}

	// Display The Game Over Screen After A Set Amount Of Time (delayBeforeAppearing). Called Upon By CharacterController.cs.
	public void PlayerIsDead ()
	{
		waveManger.SetActive (false);
		timer += Time.deltaTime;
		if (timer >= delayBeforeAppearing) 
		{
			gameOverScreen.SetActive (true);
		}
	}
}
