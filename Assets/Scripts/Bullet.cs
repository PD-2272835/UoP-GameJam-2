using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float bulletSpeed = 15f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.down * bulletSpeed, ForceMode2D.Impulse); //Vector2.down because gun sprite is rotated so bullet needs to shoot in weird direction
    }

    private void Update()
    {

        //Destroy(gameObject);
    }
}
