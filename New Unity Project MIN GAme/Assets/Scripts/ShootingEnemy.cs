using UnityEngine;
using System.Collections;

public class ShootingEnemy : Enemy {


    public GunController gun;
    public float timeToShoot;
    float timer;


    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if(timer > timeToShoot)
        {
            gun.Shoot();
            timer = 0;
        }
    }
}
