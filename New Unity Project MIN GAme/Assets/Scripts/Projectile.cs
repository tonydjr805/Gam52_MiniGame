using UnityEngine;
using System.Collections;

public class Projectile : Actor 
{
	float speed = 10;
    float timer;
    TrailRenderer trail;

	public void SetSpeed(float newSpeed)
	{
		speed = newSpeed;
	}

    public override void OnEnable()
    {
        base.OnEnable();
        timer = 0;
        trail = GetComponent<TrailRenderer>();
    }


    // Update is called once per frame
    void Update ()
	{
        timer += Time.deltaTime;
        if(timer > 2)
        {
            ObjectPooling.instance.DestroyAPS(gameObject);
            trail.Clear();
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        trail.Clear();
        ObjectPooling.instance.DestroyAPS(gameObject);
    }
}
