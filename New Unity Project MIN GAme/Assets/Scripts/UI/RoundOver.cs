using UnityEngine;
using System.Collections;

public class RoundOver : MonoBehaviour 
{
	public GameObject roundOverFx = null;

	public bool wave2 = false;
	public bool wave3 = false;
	public bool wave4 = false;
	public bool wave5 = false;

	public bool wave2FX = false;
	public bool wave3FX = false;
	public bool wave4FX = false;
	public bool wave5FX = false;

	void Start () 
	{
		wave2 = false;
		wave3 = false;
		wave4 = false;
		wave5 = false;

		wave2FX = false;
		wave3FX = false;
		wave4FX = false;
		wave5FX = false;
	}

	public void Wave1Over () 
	{
		if (wave2 == false && wave2FX == false) 
		{
			Instantiate (roundOverFx, transform.position, transform.rotation);
			wave2FX = true;
		}
	}

	public void Wave2Over () 
	{
		if (wave3 == false && wave3FX == false) 
		{
			Instantiate (roundOverFx, transform.position, transform.rotation);
			wave3FX = true;
		}
	}

	public void Wave3Over () 
	{
		if (wave4 == false && wave4FX == false) 
		{
			Instantiate (roundOverFx, transform.position, transform.rotation);
			wave4FX = true;
		}
	}

	public void Wave4Over () 
	{
		if (wave4 == false && wave4FX == false) 
		{
			Instantiate (roundOverFx, transform.position, transform.rotation);
			wave4FX = true;
		}
	}
}
