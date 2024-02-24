using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float MinAngle;
    public float MaxAngle;
    public Transform CameraAxisTransform;
    public float RotateSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var newAngleY = transform.localEulerAngles.y + Time.deltaTime * RotateSpeed * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, newAngleY, 0);



        var NewAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotateSpeed * Input.GetAxis("Mouse Y");
        

        if (NewAngleX > 180)
            NewAngleX -= 360;
        NewAngleX = Mathf.Clamp(NewAngleX, MaxAngle, MinAngle);



        CameraAxisTransform.localEulerAngles = new Vector3(NewAngleX, 0, 0);


    }
}