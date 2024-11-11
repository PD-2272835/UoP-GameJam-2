using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private float verticalTranslation;

    private float horizontalTranslation;
    private SpriteRenderer spriteRenderer;
    private GunHandler GunHandler;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GunHandler = GetComponent<GunHandler>();
    }

    //simple movement
    void Update()
    {
        verticalTranslation = Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed;
        horizontalTranslation = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed;

        if (horizontalTranslation < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (horizontalTranslation > 0)
        {
            spriteRenderer.flipX = false;
        }

        transform.Translate(horizontalTranslation, verticalTranslation, 0f);

        if (Input.GetButtonDown("Fire1"))
        {
            GunHandler.FireBullet();
        }
    }
}
