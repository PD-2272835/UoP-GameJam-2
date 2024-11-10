using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviour : Enemy
{
    void FixedUpdate()
    {
        if (DistanceFromPlayer() < detectionDistance)
        {
            SetTargetPosition(player.position);
            MoveToTargetPosition();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            healthManager.TakeDamage(attackDamage);
        }
    }
}
