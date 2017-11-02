using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class Actor : MonoBehaviour, IDamageable
{
    [SerializeField] private float damage = 1;
    [SerializeField] private float hitPoints = 1;
    [SerializeField] protected bool usePhysics = true;
    [SerializeField] protected Vector3 movementDirection;
    [SerializeField] private GameObject deathPrefab;
    private float maxHitpoint;
    protected Rigidbody rigidbody = null;
    protected GameObject source;

    public float Speed
    {
        get
        {
            if (!usePhysics)
                return rigidbody.velocity.magnitude;
            else
                return movementDirection.magnitude;
        }
        set
        {
            if (rigidbody == null)
                rigidbody = GetComponent<Rigidbody>();
            Vector3 newVelocity;
            if (rigidbody.velocity == Vector3.zero)
                newVelocity = transform.forward;
            else
                newVelocity = rigidbody.velocity.normalized;

            newVelocity *= value;
            rigidbody.velocity = newVelocity;
        }
    }


    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Start()
    {
        maxHitpoint = hitPoints;
    }

    public void OnEnable()
    {
        hitPoints = maxHitpoint;
        rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        MoveByVector(movementDirection);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        Actor actor = collision.transform.gameObject.GetComponent<Actor>();
        if (actor != null)
        {
            actor.TakeDamage(damage);
        }
    }
    protected void OnTriggerEnter(Collider other)
    {
        Actor actor = other.transform.gameObject.GetComponent<Actor>();
        if (actor != null)
        {
            actor.TakeDamage(damage);
        }
    }

    protected void MoveByVector(Vector3 movement)
    {
        if (!usePhysics)
        {
            transform.position += movement * Time.fixedDeltaTime;
        }
        else
        {
            rigidbody.velocity = movement;
        }
    }
    
    public void TakeDamage(float damageAmount)
    {
        hitPoints -= damageAmount;
        if (hitPoints <= 0)
        {
            if(deathPrefab != null)
                Instantiate(deathPrefab, transform.position, Quaternion.identity);

            //ObjectPooling.instance.DestroyAPS(gameObject);
        }
    }

    public void SetSource(GameObject newSource)
    {
        source = newSource;
    }

}
