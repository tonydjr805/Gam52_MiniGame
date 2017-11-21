using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : Actor 
{
	public enum State
	{
		Idle, Chasing, Attacking
	};
	State currentState;
	
	NavMeshAgent pathfinder;
	Actor targetActor;
	Transform target;
	Material skinmaterial;

	Color orginalColour;

	float attackDistanceThreshold = 2.5f;
	float timeBetweenAttacks = 1;
	float damage = 1;

	float nextAttackTime;
	//Vector3 myCollisionCollider;
	//float targetCollisionCollider;

	bool hasTarget;

	// Use this to overide start function in Actor script
	protected override void Start () 
	{
		base.Start ();
		pathfinder = GetComponent<NavMeshAgent> ();
		skinmaterial = GetComponent<Renderer> ().material;
		orginalColour = skinmaterial.color;

		if (GameObject.FindGameObjectWithTag ("Player") != null) 
		{
			currentState = State.Chasing;
			hasTarget = true;

			target = GameObject.FindGameObjectWithTag ("Player").transform;
			targetActor = target.GetComponent<Actor> ();
			targetActor.OnDeath += OnTargetDeath;

			//myCollisionCollider = GetComponent<BoxCollider> ().size;
			//targetCollisionCollider = target.GetComponent<CapsuleCollider> ().radius;

			StartCoroutine (UpdatePath ());
		}
	}

	void OnTargetDeath()
	{
		hasTarget = false;
		currentState = State.Idle;
	}
	
	//  this is to animate an attack towards the player
	void Update () 
	{
		if (hasTarget)
		{
			if (Time.time > nextAttackTime) 
			{
				float sqrDstToTarget = (target.position - transform.position).sqrMagnitude;
				if (sqrDstToTarget < Mathf.Pow (attackDistanceThreshold, 2)) {
					nextAttackTime = Time.time + timeBetweenAttacks;

					StartCoroutine (Attack ());
				}
			}
		}
	}

	IEnumerator Attack()
	{
		currentState = State.Attacking;
		pathfinder.enabled = false;
		
		Vector3 originalPosition = transform.position;
		Vector3 attackPosition = target.position;

		float attackSpeed = 3;
		float percent = 0;

		skinmaterial.color = Color.red;
		bool hasAppliedDamage = false;

		while (percent <= 1) 
		{
			if (percent >= .5f && !hasAppliedDamage) 
			{
				hasAppliedDamage = true;
				targetActor.TakeDamage (damage);
			}
			percent += Time.deltaTime * attackSpeed;
			float interpolation = (-Mathf.Pow(percent, 2)+ percent) * 4;
			transform.position = Vector3.Lerp (originalPosition, attackPosition, interpolation);

			yield return null;
		}

		skinmaterial.color = orginalColour;
		currentState = State.Chasing;
		pathfinder.enabled = true;
	}

	// this is for the enemy to update path to find player
	IEnumerator UpdatePath()
	{
		float refreshRate = .25f;

		while (hasTarget) 
		{
			if (currentState == State.Chasing) 
			{
				Vector3 targetPosition = new Vector3 (target.position.x, 0, target.position.z);
				//Vector3 dirToTarget = (target.position - transform.position).normalized;
				//Vector3 targetPosition = target.position - dirToTarget * (myCollisionCollider + targetCollisionCollider);
				if (!dead) 
				{
					pathfinder.SetDestination (targetPosition);
				}
			}
			yield return new WaitForSeconds (refreshRate);
				
		}
	}
}

