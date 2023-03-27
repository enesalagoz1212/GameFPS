using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public float sensivity = 3;
    
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayerBody();
    }
    private float rotateY=0;
    private float rotateX=0;
    private void RotatePlayerBody()
    {
        rotateY += sensivity * Input.GetAxis("Mouse Y")*-1;
        rotateX += sensivity * Input.GetAxis("Mouse X");
        rotateY = Mathf.Clamp(rotateY, -80, 80);
        transform.eulerAngles=new Vector3(rotateY,rotateX,0);
    }
}
