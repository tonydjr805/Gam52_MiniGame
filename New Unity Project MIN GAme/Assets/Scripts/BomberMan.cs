using UnityEngine;
using System.Collections;

public class BomberMan : Enemy {

    MapGeneraotor map;
    public bool playerInSight;
    public float redius = 10;
    Transform newTarget;

    public override void Start()
    {
        base.Start();
        map = FindObjectOfType<MapGeneraotor>();
        Petrol();
    }

    public override void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        healthSlider.value = hitPoints;
        if (distanceToTarget < redius)
        {
            target = player;
            aiState = AIState.Attack;
            playerInSight = true;
            SwithState();
        }
        else
        {
            aiState = AIState.Petrol;
            playerInSight = false;
        }
            

        if (distanceToTarget < 2)
        {
            aiState = AIState.Smoke;
            SwithState();
        }
           


        if(gameObject.activeInHierarchy)
        {
            if (!playerInSight)
            {
                if (!navAgent.pathPending)
                {
                    if (navAgent.remainingDistance <= navAgent.stoppingDistance)
                    {
                        if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
                        {
                            Petrol();
                        }
                    }
                }
            }
        }
    }

    public override void SwithState()
    {
        base.SwithState();
        switch (aiState)
        {
            case AIState.Petrol:
                Petrol();
                break;
            case AIState.Smoke:
                BlowUp();
                break;
        }
    }

    void BlowUp()
    {
        TakeDamage(maxHitpoint);
    }

    void Petrol()
    {
        navAgent.speed = navAgent.speed + Time.deltaTime / 10;
        StartCoroutine(PetrolCo());
    }

    IEnumerator PetrolCo()
    {

        if (!playerInSight)
        {
            newTarget = map.GetRandomOpenTile();
            yield return null;
            target = newTarget;
            navAgent.SetDestination(target.position);
            
            
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, redius);
    }
}
