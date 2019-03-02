using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCube : MonoBehaviour
{
    int multiplier = 20;

    float accelXStart;
    float accelYStart;
    float accelZStart;

    public Text text3;

    public Toggle toggleMove;


    // Start is called before the first frame update
    void Start()
    {
        accelXStart = Input.acceleration.x * multiplier;
        accelYStart = Input.acceleration.y * multiplier;
        accelZStart = Input.acceleration.z * multiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleMove.isOn)
        {
            float accelX = Mathf.Round((Input.acceleration.x * multiplier) - accelXStart);
            float accelY = Mathf.Round((Input.acceleration.y * multiplier) - accelYStart);
            float accelZ = Mathf.Round((Input.acceleration.z * multiplier) - accelZStart);

            float constant = 0.5f;
            int minAccel = 3;
            if (accelX >= minAccel || accelX <= -minAccel || accelY >= minAccel || accelY <= -minAccel || accelZ >= minAccel || accelZ <= -minAccel)
            {
                constant = 2;
                float transX = accelY * constant;
                float transY = accelZ * constant;
                float transZ = accelX * constant;
                transform.Translate(new Vector3(transX, 0, transZ) * (0.1f * Time.deltaTime));
            }
            else
            {
                constant = 0;
            }
            //transform.Translate(new Vector3(1, 1, 1) * Time.deltaTime, Space.World);
            text3.text = Mathf.Round(transform.position.x).ToString() + ", " + Mathf.Round(transform.position.y).ToString() + ", " + Mathf.Round(transform.position.z).ToString();

        }

    }
}
