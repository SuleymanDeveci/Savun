using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public Camera cam;
    public Joystick joystick;

    public float angle;

    public Vector2 mousePos;
    public Vector2 lookDir;


    // Update is called once per frame
    void Update()
    {
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);  Windows için silah kontrolü

    }

    private void FixedUpdate()
    {


        //lookDir = mousePos - rb.position;   Windows için silah kontrolü

        lookDir.x = joystick.Horizontal;
        lookDir.y = joystick.Vertical;

        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (angle < -90)
        {
            transform.localScale = new Vector3(transform.localScale.x, -0.06f, transform.localScale.z);
                
            
        }
        else if (angle > 90)
        {
            transform.localScale = new Vector3(transform.localScale.x, -0.06f, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, 0.06f, transform.localScale.z);
        }


    }
}
