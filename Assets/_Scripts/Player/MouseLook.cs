using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    //variables to deal with mouse movement/sensetivity
    public float m_MouseSensitivity = 15F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;

    private bool isPaused = true;

    // Use this for initialization
    void Start()
    {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;

        isPaused = false;
    }

    void Update()
    {
        if (!isPaused)
        {
            //Rotate the x axis
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * m_MouseSensitivity;

            //rotate the y, with a maximum rotation upwards so you dont do a backflip or front flip
            rotationY += Input.GetAxis("Mouse Y") * m_MouseSensitivity;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            //change the rotation of the camera transform
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void UnPause()
    {
        isPaused = false;
    }
}
