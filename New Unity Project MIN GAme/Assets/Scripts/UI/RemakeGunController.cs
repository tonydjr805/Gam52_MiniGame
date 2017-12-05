using UnityEngine;
using System.Collections;

public class RemakeGunController : MonoBehaviour 
{
	public Transform weaponHolder;
	public Gun startingGun;
	Gun equippedGun;

	// Gun:
	public GameObject gun = null;

	// Ammo Display:
	public int ammo = 0;
	public GameObject bullet1 = null;
	public GameObject bullet2 = null;
	public GameObject bullet3 = null;
	public GameObject bullet4 = null;
	public GameObject bullet5 = null;
	public GameObject bullet6 = null;
	public GameObject bullet7 = null;
	public GameObject bullet8 = null;
	public GameObject bullet9 = null;
	public GameObject bullet10 = null;
	public GameObject bullet11 = null;
	public GameObject bullet12 = null;
	public GameObject bullet13 = null;
	public GameObject bullet14 = null;
	public GameObject bullet15 = null;
	public GameObject bullet16 = null;
	public GameObject bullet17 = null;
	public GameObject bullet18 = null;
	public GameObject bullet19 = null;
	public GameObject bullet20 = null;

	void Start()
	{
		// Sets The Player's Ammo Count to 20:
		ammo = 20;

		if (startingGun != null) 
		{
			EquipGun(startingGun);
		}
	}

	void update () 
	{
		// Tells The Gun To Fire
		if (Input.GetMouseButtonDown (0)) 
		{
			// Only Allows A Shot To Be Fired If The Player Has At Least One Bullet.
			if (ammo >= 1) 
			{
				// Reduces Ammo Count, Calls Upon Gun.cs To Fire A Projectille.
				ammo--;
				gun.GetComponent<Gun>().Shoot ();
			}
		}

		// Restricts Ammo Count To Twenty Bullets.
		if (ammo > 20) 
		{
			ammo = 20;
		}

		// Displays Ammo Count On Screen
		if (ammo == 20)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (true);
			bullet9.SetActive (true);
			bullet10.SetActive (true);
			bullet11.SetActive (true);
			bullet12.SetActive (true);
			bullet13.SetActive (true);
			bullet14.SetActive (true);
			bullet15.SetActive (true);
			bullet16.SetActive (true);
			bullet17.SetActive (true);
			bullet18.SetActive (true);
			bullet19.SetActive (true);
			bullet20.SetActive (true);
		}

		if (ammo == 19)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (true);
			bullet9.SetActive (true);
			bullet10.SetActive (true);
			bullet11.SetActive (true);
			bullet12.SetActive (true);
			bullet13.SetActive (true);
			bullet14.SetActive (true);
			bullet15.SetActive (true);
			bullet16.SetActive (true);
			bullet17.SetActive (true);
			bullet18.SetActive (true);
			bullet19.SetActive (true);
			bullet20.SetActive (false);
		}

		if (ammo == 18)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (true);
			bullet9.SetActive (true);
			bullet10.SetActive (true);
			bullet11.SetActive (true);
			bullet12.SetActive (true);
			bullet13.SetActive (true);
			bullet14.SetActive (true);
			bullet15.SetActive (true);
			bullet16.SetActive (true);
			bullet17.SetActive (true);
			bullet18.SetActive (true);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 17)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (true);
			bullet9.SetActive (true);
			bullet10.SetActive (true);
			bullet11.SetActive (true);
			bullet12.SetActive (true);
			bullet13.SetActive (true);
			bullet14.SetActive (true);
			bullet15.SetActive (true);
			bullet16.SetActive (true);
			bullet17.SetActive (true);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 16)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (true);
			bullet9.SetActive (true);
			bullet10.SetActive (true);
			bullet11.SetActive (true);
			bullet12.SetActive (true);
			bullet13.SetActive (true);
			bullet14.SetActive (true);
			bullet15.SetActive (true);
			bullet16.SetActive (true);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 15)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (true);
			bullet9.SetActive (true);
			bullet10.SetActive (true);
			bullet11.SetActive (true);
			bullet12.SetActive (true);
			bullet13.SetActive (true);
			bullet14.SetActive (true);
			bullet15.SetActive (true);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 14)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (true);
			bullet9.SetActive (true);
			bullet10.SetActive (true);
			bullet11.SetActive (true);
			bullet12.SetActive (true);
			bullet13.SetActive (true);
			bullet14.SetActive (true);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 13)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (true);
			bullet9.SetActive (true);
			bullet10.SetActive (true);
			bullet11.SetActive (true);
			bullet12.SetActive (true);
			bullet13.SetActive (true);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 12)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (true);
			bullet9.SetActive (true);
			bullet10.SetActive (true);
			bullet11.SetActive (true);
			bullet12.SetActive (true);
			bullet13.SetActive (false);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 11)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (true);
			bullet9.SetActive (true);
			bullet10.SetActive (true);
			bullet11.SetActive (true);
			bullet12.SetActive (false);
			bullet13.SetActive (false);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 10)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (true);
			bullet9.SetActive (true);
			bullet10.SetActive (true);
			bullet11.SetActive (false);
			bullet12.SetActive (false);
			bullet13.SetActive (false);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 9)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (true);
			bullet9.SetActive (true);
			bullet10.SetActive (false);
			bullet11.SetActive (false);
			bullet12.SetActive (false);
			bullet13.SetActive (false);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 8)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (true);
			bullet9.SetActive (false);
			bullet10.SetActive (false);
			bullet11.SetActive (false);
			bullet12.SetActive (false);
			bullet13.SetActive (false);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 7)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (true);
			bullet8.SetActive (false);
			bullet9.SetActive (false);
			bullet10.SetActive (false);
			bullet11.SetActive (false);
			bullet12.SetActive (false);
			bullet13.SetActive (false);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 6)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (true);
			bullet7.SetActive (false);
			bullet8.SetActive (false);
			bullet9.SetActive (false);
			bullet10.SetActive (false);
			bullet11.SetActive (false);
			bullet12.SetActive (false);
			bullet13.SetActive (false);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 5)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (true);
			bullet6.SetActive (false);
			bullet7.SetActive (false);
			bullet8.SetActive (false);
			bullet9.SetActive (false);
			bullet10.SetActive (false);
			bullet11.SetActive (false);
			bullet12.SetActive (false);
			bullet13.SetActive (false);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 4)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (true);
			bullet5.SetActive (false);
			bullet6.SetActive (false);
			bullet7.SetActive (false);
			bullet8.SetActive (false);
			bullet9.SetActive (false);
			bullet10.SetActive (false);
			bullet11.SetActive (false);
			bullet12.SetActive (false);
			bullet13.SetActive (false);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 3)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (true);
			bullet4.SetActive (false);
			bullet5.SetActive (false);
			bullet6.SetActive (false);
			bullet7.SetActive (false);
			bullet8.SetActive (false);
			bullet9.SetActive (false);
			bullet10.SetActive (false);
			bullet11.SetActive (false);
			bullet12.SetActive (false);
			bullet13.SetActive (false);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 2)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (true);
			bullet3.SetActive (false);
			bullet4.SetActive (false);
			bullet5.SetActive (false);
			bullet6.SetActive (false);
			bullet7.SetActive (false);
			bullet8.SetActive (false);
			bullet9.SetActive (false);
			bullet10.SetActive (false);
			bullet11.SetActive (false);
			bullet12.SetActive (false);
			bullet13.SetActive (false);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 1)
		{
			bullet1.SetActive (true);
			bullet2.SetActive (false);
			bullet3.SetActive (false);
			bullet4.SetActive (false);
			bullet5.SetActive (false);
			bullet6.SetActive (false);
			bullet7.SetActive (false);
			bullet8.SetActive (false);
			bullet9.SetActive (false);
			bullet10.SetActive (false);
			bullet11.SetActive (false);
			bullet12.SetActive (false);
			bullet13.SetActive (false);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}

		if (ammo == 0)
		{
			bullet1.SetActive (false);
			bullet2.SetActive (false);
			bullet3.SetActive (false);
			bullet4.SetActive (false);
			bullet5.SetActive (false);
			bullet6.SetActive (false);
			bullet7.SetActive (false);
			bullet8.SetActive (false);
			bullet9.SetActive (false);
			bullet10.SetActive (false);
			bullet11.SetActive (false);
			bullet12.SetActive (false);
			bullet13.SetActive (false);
			bullet14.SetActive (false);
			bullet15.SetActive (false);
			bullet16.SetActive (false);
			bullet17.SetActive (false);
			bullet18.SetActive (false);
			bullet19.SetActive (false);
			bullet20.SetActive (false);
		}
	}

	public void EquipGun(Gun gunToEquip)
	{
		if (equippedGun != null)
		{
			Destroy (equippedGun.gameObject);
		}
		equippedGun = Instantiate (gunToEquip, weaponHolder.position, weaponHolder.rotation) as Gun;
		equippedGun.transform.parent = weaponHolder;
	}

	public void Shoot()
	{
		if (equippedGun != null) 
		{
			equippedGun.Shoot ();
		}
	}
}