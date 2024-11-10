using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 1;
    private float movementSpeed;

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
}
