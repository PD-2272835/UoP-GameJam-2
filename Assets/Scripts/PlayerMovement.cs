using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private float verticalTranslation;
    private float horizontalTranslation;

    //simple movement
    void FixedUpdate()
    {
        verticalTranslation = Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed;
        horizontalTranslation = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movementSpeed;

        transform.Translate(horizontalTranslation, verticalTranslation, 0f);
    }
}
