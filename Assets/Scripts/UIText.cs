using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LabApp;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    // Adjust the speed for the application.

    private GameObject target;
    private Rigidbody targetRB;
    private LabImageBehaviour script;

    public Text text1;
    public Text text2;
    private float startDeviceEuler;

    private Main mainComponent;
    private MoveCube containerComponent;

    public static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject cube = GameObject.Find("Cube");
        mainComponent = cube.GetComponent<Main>();

        GameObject container = GameObject.Find("Container");
        containerComponent = container.GetComponent<MoveCube>();
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = "Accel z: " + mainComponent.acceleration.ToString();
        text2.text = "Rotate z: " + mainComponent.rotation.ToString();
    }

}