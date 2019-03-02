using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LabApp;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    // Adjust the speed for the application.

    private GameObject target;
    private Rigidbody targetRB;
    private LabImageBehaviour script;

    private float startDeviceEuler;

    public float rotation;
    public float acceleration;

    public Text text1;
    public Text text2;
    public Text text3;

    public Toggle toggleMove;

    int multiplier = 10;

    float accelXStart;
    float accelYStart;
    float accelZStart;


    public static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;

        targetRB = GetComponent<Rigidbody>();
        target = GameObject.Find("Cube");


        accelXStart = Input.acceleration.x * multiplier;
        accelYStart = Input.acceleration.y * multiplier;
        accelZStart = Input.acceleration.z * multiplier;

    }

    // Update is called once per frame
    void Update()
    {
        

        // Rotate object with gyroscope
        Quaternion deviceRotation = GyroToUnity(Input.gyro.attitude);
        Vector3 deviceEuler = deviceRotation.eulerAngles;
        Vector3 transformEuler = transform.rotation.eulerAngles;
        //transform.Rotate((new Vector3(0, deviceEuler.z-startDeviceEuler, 0)) * (0.1f * Time.deltaTime));
        text2.text = Mathf.Round(deviceEuler.x).ToString() + ", " + Mathf.Round(deviceEuler.y).ToString() + ", " + Mathf.Round(deviceEuler.z).ToString();

        // Move object with accelerometer
        float accelX = Input.acceleration.x * multiplier;
        float accelY = Input.acceleration.y * multiplier;
        float accelZ = Input.acceleration.z * multiplier;
        text1.text = Mathf.Round(accelX - accelXStart).ToString() + ", " + Mathf.Round(accelY - accelYStart).ToString() + ", " + Mathf.Round(accelZ - accelZStart).ToString();

        //text3.text = Mathf.Round(rotX).ToString() + ", " + Mathf.Round(rotY).ToString() + ", " + Mathf.Round(rotZ).ToString();

        transform.rotation = Quaternion.Slerp(transform.rotation, deviceRotation, 1.0f * Time.deltaTime);


        ////transform.Translate(new Vector3(accelY - accelYStart, accelZ - accelZStart, accelX - accelYStart) * (1.0f * Time.deltaTime));
        ////transform.Translate(new Vector3(1, 1, 1) * Time.deltaTime, Space.World);

        text3.text = Mathf.Round(transform.position.x).ToString() + ", " + Mathf.Round(transform.position.y).ToString() + ", " + Mathf.Round(transform.position.z).ToString();
    }


}
