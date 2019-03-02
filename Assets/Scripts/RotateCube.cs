using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LabApp;
using UnityEngine.UI;

public class RotateCube : MonoBehaviour
{
    // Adjust the speed for the application.

    private GameObject target;
    private Rigidbody targetRB;
    private LabImageBehaviour script;


    public static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        

        // Rotate object with gyroscope
        Quaternion deviceRotation = GyroToUnity(Input.gyro.attitude);
    
        transform.rotation = Quaternion.Slerp(transform.rotation, deviceRotation, 1.0f * Time.deltaTime);


        ////transform.Translate(new Vector3(accelY - accelYStart, accelZ - accelZStart, accelX - accelYStart) * (1.0f * Time.deltaTime));
        ////transform.Translate(new Vector3(1, 1, 1) * Time.deltaTime, Space.World);

    }


}
