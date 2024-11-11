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
        if (collision.gameObject.CompareTag("Player"))
        {
            healthManager.TakeDamage(attackDamage);
        }
    }
}
