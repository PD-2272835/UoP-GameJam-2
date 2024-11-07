using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private Vector3 mousePosition;
    private Vector3 targetPosition;
    private Vector2 targetDirection;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Munchy2007 - https://discussions.unity.com/t/rotating-a-sprite-to-face-mouse-target/90164
        targetPosition = cam.ScreenToWorldPoint(Input.mousePosition); // cursor position in world space
        targetDirection = transform.position - targetPosition; //vector pointing from this object's position towards the cursor
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetDirection); //rotate parent object to face forward to target direction
        
        if (transform.localEulerAngles.z > 180f)
        {
            spriteRenderer.flipY = true;
        } else
        {
            spriteRenderer.flipY = false;
        }
    }   
}
