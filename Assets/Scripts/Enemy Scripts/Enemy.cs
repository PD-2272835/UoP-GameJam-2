using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public HealthManager healthManager;

    public float detectionDistance;
    public int attackDamage;


    [SerializeField] public Vector2 targetPosition { get; private set; } 
    [SerializeField] private float movementSpeed;

    private int health = 1;


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


