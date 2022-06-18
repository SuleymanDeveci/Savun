using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Joystick joystick;
    public Slider slider;
    

    public bool shootFlag = true;

    public float atisHizi;


    private void Start()
    {
        atisHizi = slider.value;
        shootFlag = true;
    }





    void Update()
    {
        /*
        if (Input.GetButtonDown("Fire1"))            // Windows silah sýkma kontrolü
        {
            Shoot();
        }
        */  


        if((joystick.Horizontal > 0.05f || joystick.Vertical > 0.05f) && shootFlag == true)
        {
            shootFlag = false;
            Shoot();
            StartCoroutine(bekle(atisHizi));
        }
        else if ((joystick.Horizontal < -0.05f || joystick.Vertical < -0.05f) && shootFlag == true)
        {
            shootFlag = false;
            Shoot();
            StartCoroutine(bekle(atisHizi));
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        
    }

    private void FixedUpdate()
    {
        atisHizi = slider.value;
    }


    IEnumerator bekle(float zaman)
    {
        //Beklemeden önce 

        
        yield return new WaitForSecondsRealtime(zaman); //Beklenecek zaman
        
        shootFlag = true;


        //Beklemeden sonra



    }
}
