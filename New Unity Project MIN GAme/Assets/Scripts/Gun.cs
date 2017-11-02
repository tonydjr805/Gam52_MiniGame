using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour 
{
	public Transform muzzle;
	public Projectile bullets;
	public float secBetweenShots = 100;
	public float muzzleVelocity = 35;

	float nextShotTime;

	public void Shoot()
	{
		if (Time.time > nextShotTime)
		{
			nextShotTime = Time.time + secBetweenShots / 1000;
			Projectile newProjectile = Instantiate (bullets, muzzle.position, muzzle.rotation) as Projectile;
			newProjectile.SetSpeed (muzzleVelocity);
		}
	}
}