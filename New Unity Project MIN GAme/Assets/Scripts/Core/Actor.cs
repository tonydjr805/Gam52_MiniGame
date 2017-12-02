using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class Actor : MonoBehaviour, IDamageable
{
    [SerializeField] internal float damage = 1;
    [SerializeField] protected float maxHitpoint;
    [SerializeField] private bool isAI;
    [SerializeField] protected bool usePhysics = true;
    [SerializeField] protected Vector3 movementDirection;
    [SerializeField] private string deathPrefab;
    protected float hitPoints;
    protected Rigidbody body = null;
    protected GameObject source;
    public string[] ObjectsToFall;
    public float chanceToFall;
    public float Speed
    {
        get
        {
            if (!usePhysics)
                return body.velocity.magnitude;
            else
                return movementDirection.magnitude;
        }
        set
        {
            if (body == null)
                body = GetComponent<Rigidbody>();
            Vector3 newVelocity;
            if (body.velocity == Vector3.zero)
                newVelocity = transform.forward;
            else
                newVelocity = body.velocity.normalized;

            newVelocity *= value;
            body.velocity = newVelocity;
        }
    }


    protected virtual void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public virtual void Start()
    {
        maxHitpoint = hitPoints;
    }

    public virtual void OnEnable()
    {
        hitPoints = maxHitpoint;
        body = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        MoveByVector(movementDirection);
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        Actor actor = collision.gameObject.GetComponent<Actor>();
        if (actor != null)
        {
            actor.TakeDamage(damage);
        }
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        Actor actor = other.GetComponent<Actor>();
        if (actor != null)
        {
            actor.TakeDamage(damage);
        }

        if (other.tag == "Collectable" && !isAI)
        {
            GameManager.instance.GivePoint();
            ObjectPooling.instance.DestroyAPS(other.gameObject);
        }
    }

    protected void MoveByVector(Vector3 movement)
    {
        if (isAI)
            return;

        if (!usePhysics)
        {
            transform.position += movement * Time.fixedDeltaTime;
        }
        else
        {
            body.velocity = movement;
        }
    }
    
    public void TakeDamage(float damageAmount)
    {
        hitPoints -= damageAmount;

        if (hitPoints <= 0)
        {
            if(isAI)
            {
                chanceToFall = Random.Range(0, 10);
                if (chanceToFall > 7)
                {
                    ObjectPooling.instance.InstantiateAPS(ObjectsToFall[Random.Range(0, ObjectsToFall.Length)], transform.position, Quaternion.identity);
                    Debug.Log(chanceToFall);
                }
            }
           
            if (string.IsNullOrEmpty(deathPrefab))
                ObjectPooling.instance.InstantiateAPS(deathPrefab, transform.position, Quaternion.identity);

            ObjectPooling.instance.DestroyAPS(gameObject);
        }
    }

    public void SetSource(GameObject newSource)
    {
        source = newSource;
    }

    private void OnDestroy()
    {
        Debug.LogWarning("Destroy" + gameObject.name);
    }

}
