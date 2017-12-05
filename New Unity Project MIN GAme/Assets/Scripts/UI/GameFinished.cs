using UnityEngine;
using System.Collections;

public class GameFinished : MonoBehaviour 
{
	// Win Screen:
	public GameObject gameFinishedScreen = null;
	public GameObject ui = null;

	// Time Passed Between The Death Of The 45th Enemy And Appearance Of The Win Screen:
	public float delayBeforeAppearing = 1.0f;
	public float timer = 0.0f;

	// Use This For Initialization:
	void Start ()
	{
		ui = GameObject.Find("EnemiesKilled");
		ui.SetActive (true);
	}

	// Displays The Win Screen After A Set Amount Of Time (delayBeforeApearing). Called upon by EnemyManager.cs.
	public void PlayerWon ()
	{
		ui.SetActive (false);
		timer += Time.deltaTime;
		if (timer >= delayBeforeAppearing) 
		{
			gameFinishedScreen.SetActive (true);
		}
	}
}
