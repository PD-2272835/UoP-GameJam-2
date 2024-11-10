using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour
{
    public GameObject bullet;

    private GameObject gunAimer;
    private Transform gunTransform;
    private Transform bulletOrigin;

    private Vector3 targetPosition;
    private Vector2 targetDirection;
    private Camera cam; 

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        gunAimer = transform.GetChild(0).gameObject; //references the GunAimer gameobject
        gunTransform = gunAimer.transform.GetChild(0);
        bulletOrigin = gunAimer.transform.GetChild(0).GetChild(0).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Munchy2007 - https://discussions.unity.com/t/rotating-a-sprite-to-face-mouse-target/90164
        targetPosition = cam.ScreenToWorldPoint(Input.mousePosition); // cursor position in world space
        targetDirection = transform.position - targetPosition; //vector pointing from this object's position towards the cursor
        gunAimer.transform.rotation = Quaternion.LookRotation(Vector3.forward, targetDirection); //rotate parent object to face forward to target direction
        
        if (gunAimer.transform.localEulerAngles.z > 180f)
        {
            gunTransform.localScale = new Vector3(1f, -1f, 1f);
        } else
        {
            gunTransform.localScale = Vector3.one;
        }
    }


    public void FireBullet()
    {
        Instantiate(bullet, bulletOrigin.position, gunAimer.transform.rotation);
    }
}
