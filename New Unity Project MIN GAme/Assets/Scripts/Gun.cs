using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour 
{
    public string Type;
	public Transform muzzle;
	public float secBetweenShots = 100;
	public float muzzleVelocity = 35;
    public string bulletName;
	float nextShotTime;
    public GunController gunController;

    private void OnEnable()
    {
        if(gameObject.activeInHierarchy)
        {
            gunController.equippedGun = this;
        }
       
    }

    public void Shoot()
	{
		if (Time.time > nextShotTime)
		{
			nextShotTime = Time.time + secBetweenShots / 1000;
            //Projectile newProjectile = Instantiate (bullets, muzzle.position, muzzle.rotation) as Projectile;
            GameObject newProjectile = ObjectPooling.instance.InstantiateAPS(bulletName, muzzle.position, muzzle.rotation);
            newProjectile.GetComponent<Projectile>().SetSpeed (muzzleVelocity);
		}
	}
}