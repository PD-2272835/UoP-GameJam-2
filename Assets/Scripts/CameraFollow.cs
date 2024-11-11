using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    private Vector3 playerScreenPos;
    private Camera cam;

    private Vector2 lowerBound;
    private Vector2 upperBound;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerScreenPos = cam.WorldToScreenPoint(playerPos.position);
        Debug.Log(playerScreenPos.ToString());

    }
}
