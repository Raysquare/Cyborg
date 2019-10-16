using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraControl : MonoBehaviour { 



    public float VerticalSpeed = 10.0f;


    public float pitch =10.0f;



    public GameObject cyborg;

    private void Start()
    {
        //this.transform.position = new Vector3(0.5f * HorizontalMinRange, 3.0f * mHeight, 0.5f * HorizontalMinRange);
        //transform.LookAt(new Vector3(0, 0, 0));
    }

    private void Update()
    {
        //Vector3 CurrentLocation = this.transform.position;
        //Vector3 UpdateLocation = CurrentLocation;
        //if (CurrentLocation.x < HorizontalMinRange)
        //{
        //    UpdateLocation.x = HorizontalMinRange;
        //}
        //if (CurrentLocation.x > HorizontalMaxRange)
        //{
        //    UpdateLocation.x = HorizontalMaxRange;
        //    }
        //    if (CurrentLocation.z < HorizontalMinRange)
        //    {
        //        UpdateLocation.z = HorizontalMinRange;
        //    }
        //    if (CurrentLocation.z > HorizontalMaxRange)
        //    {
        //        UpdateLocation.z = HorizontalMaxRange;
        //    }
        //if (CurrentLocation != UpdateLocation)
        //{
        //    this.transform.position = UpdateLocation;
        //}


        //yaw += HorizontalSpeed * Input.GetAxis("Mouse X");

        pitch += VerticalSpeed * Input.GetAxis("Mouse Y")*Time.deltaTime;
      
        //this.transform.eulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        Vector3 lookAtPosititon = new Vector3(cyborg.transform.position.x, cyborg.transform.position.y+pitch, cyborg.transform.position.z);
        this.transform.LookAt(lookAtPosititon);

        //if (Input.GetAxis("Horizontal") != 0)
        //{
        //    transform.Translate(Input.GetAxis("Horizontal") * MovementSpeed, 0, 0);
        //}
        //if (Input.GetAxis("Vertical") != 0)
        //{
        //    transform.Translate(0, 0, Input.GetAxis("Vertical") * MovementSpeed);
        //}


    }





}
