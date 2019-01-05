/*---------------------------------------------------------
File Name: Shoot.cs
Purpose: shoots the gravity gun
Author: Heath Parkes (heath@gargit.games)
Modified: 2019-01-05
---------------------------------------------------------*/

using System;
using UnityEngine;

public class Shoot : MonoBehaviour {


    private enum AvailableGuns { bubble, physics };
    private AvailableGuns m_CurrentGun;

    public float m_ShoveSpeed = 450.0f;
    public float m_AntiGravSpeed = 100.0f;

    // Use this for initialization
    void Start ()
    {
        m_CurrentGun = AvailableGuns.physics;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            MainShoot();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            AltShoot();
        }

        //change guns
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWeapons();
        }
    }

    //change guns
    private void ChangeWeapons()
    {
        if(m_CurrentGun == AvailableGuns.bubble)
        {
            m_CurrentGun = AvailableGuns.physics;
        }
        else
        {
            m_CurrentGun = AvailableGuns.bubble;
        }
    }

    private void MainShoot()
    {
        //this code shoots a ray towards where the camera/player is looking and does something if it hits a physics object
        Transform playerCam = Camera.main.transform;
        RaycastHit hitObject;
        Physics.Raycast(playerCam.position, playerCam.forward, out hitObject, 500f);
        if (hitObject.rigidbody != null) //if the gameobject hit by the ray is the box.
        {
            //shoot either gun
            switch(m_CurrentGun)
            {
                case AvailableGuns.bubble:
                    hitObject.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    hitObject.collider.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * m_AntiGravSpeed);
                    break;
                case AvailableGuns.physics:
                    Vector3 direction = Vector3.Normalize(playerCam.transform.position - hitObject.transform.position);
                    hitObject.rigidbody.AddForceAtPosition((direction * m_ShoveSpeed * -1.0f), hitObject.point);
                    break;
                default:
                    break;
            }
        }
    }

    private void AltShoot()
    {
        //this code shoots a ray towards where the camera/player is looking and does something if it hits a physics object
        Transform playerCam = Camera.main.transform;
        RaycastHit hitObject;
        Physics.Raycast(playerCam.position, playerCam.forward, out hitObject, 500f);
        if (hitObject.rigidbody != null) //if the gameobject hit by the ray is the box.
        {
            //shoot either gun
            switch (m_CurrentGun)
            {
                case AvailableGuns.bubble:
                    hitObject.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    break;
                case AvailableGuns.physics:
                    Vector3 direction = Vector3.Normalize(playerCam.transform.position - hitObject.transform.position);
                    hitObject.rigidbody.AddForceAtPosition((direction * m_ShoveSpeed), hitObject.point);
                    break;
                default:
                    break;
            }
        }
    }
}
