using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public int bulletDamage = 1;

    private Rigidbody2D rb;
    private float timeToLive = 1f; //ttl in seconds

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.down * bulletSpeed, ForceMode2D.Impulse); //Vector2.down because gun sprite is rotated so bullet needs to shoot in weird direction
    }


    //ghetto async
    //destroys bullet projectile after time to live has elapsed
    private IEnumerator Start()
    {
        for (float age = 0; age < timeToLive; age += Time.deltaTime)
        {
            yield return null;
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().Damage(bulletDamage);
            Destroy(gameObject);
        }
    }
}