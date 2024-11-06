using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour
{
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
        mousePosition = Input.mousePosition;
        targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
        targetDirection = new Vector3(transform.position.x - targetPosition.x, transform.position.y - targetPosition.y, 0f);
        
    }
}
