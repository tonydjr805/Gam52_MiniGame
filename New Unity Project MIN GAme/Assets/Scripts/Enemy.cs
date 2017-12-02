using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum AIState
{
    Petrol,
    Alert,
    Attack,
    Smoke,
    Drink,
    Die
}

public class Enemy : Actor {

    public AIState aiState;
    protected NavMeshAgent navAgent;
    protected Transform player;
    protected Transform target;
    public Light pLight;
    public Canvas enemyCanvas;
    public Slider healthSlider;
    Camera cam;

    

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        cam = Camera.main;
        aiState = AIState.Attack;
        navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthSlider.maxValue = maxHitpoint;
        healthSlider.value = healthSlider.maxValue; 


        if (target == null)
            target = player;
    }	
	// Update is called once per frame
    public virtual void Update () {
        SwithState();
        enemyCanvas.transform.LookAt(cam.transform);
        healthSlider.value = hitPoints;
    }

    public virtual void Attack()
    {
        navAgent.SetDestination(target.position);
        navAgent.speed = navAgent.speed + Time.deltaTime / 10;
    }


    public virtual void SwithState()
    {
        switch (aiState)
        {
            case AIState.Attack:
                Attack();
                break;
            case AIState.Die:
                pLight.color = Color.red;
                break;
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        
        base.OnCollisionEnter(collision);
        
    }
}
