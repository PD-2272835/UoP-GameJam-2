using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public HealthManager healthManager;
    public GameObject blood;

    public float detectionDistance;
    public int attackDamage;

    [SerializeField] public Vector2 targetPosition { get; private set; } 
    [SerializeField] private float movementSpeed;

    private int health = 1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthManager = GameObject.FindGameObjectWithTag("Health_Manager").GetComponent<HealthManager>();
    }


    //take damage
    public void Damage(int _damageDealt)
    {
        health -= _damageDealt;
        if (health <= 0)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        BoxCollider2D collider = (BoxCollider2D)gameObject.GetComponent<Collider2D>();
        Vector3 colliderWorldPosition = collider.bounds.center;
        Instantiate(blood, colliderWorldPosition, transform.rotation);
        Destroy(gameObject);
    }

    public void SetTargetPosition(Vector2 _newTargetPosition)
    {
        targetPosition = _newTargetPosition;
    }

    public void MoveToTargetPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }

    public float DistanceFromPlayer()
    {
        return Vector2.Distance(player.position, transform.position);
    }
}


