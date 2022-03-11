using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    const float sensorLength = 5;   //max distance
    const float frontSensor = 1;    //starting point of the front sensor
    const float frontSideSensor = 0.5f;
    const float frontSensorAngle = 30;


    public void Check()
    {

        RaycastHit hit;     //checks if we hit something, and the angle since there are multiple sensors
        float avoidDirection = 0;   //direction we will need to avoid to


        Vector3 frontPosition = transform.position + (transform.forward * frontSensor);
        if (DrawSensors(frontPosition, Vector3.forward, sensorLength, out hit))
        {
            if (hit.normal.x < 0)
            {
                avoidDirection = -0.25f; //-1 will take it to the left <=
            }
            else
            {
                avoidDirection = 0.25f; //vice versa
            }
        }
        avoidDirection -= FrontSideSensors(frontPosition, out hit, 1);  //basically the frontposition, 1, and -1 determining the left and right neded to go.
        avoidDirection += FrontSideSensors(frontPosition, out hit, -1);

    }
    bool DrawSensors(Vector3 sensorPosition, Vector3 direction, float length, out RaycastHit hit)   //doesnt just draws, but detects
    {
        if (Physics.Raycast(sensorPosition, transform.forward, out hit, length))
        {
            Debug.DrawLine(sensorPosition, hit.point, Color.black);
            return true; // cause it hit something
        }
        return false;
    }

    float FrontSideSensors(Vector3 frontPosition, out RaycastHit hit, float sensorDirection)
    {
        float avoidDirection = 0;

        Vector3 sensorPosition = frontPosition + (transform.right * frontSideSensor * sensorDirection);     // * sensorDirection so transform.right turns transform left

        Vector3 sensorAngle = Quaternion.AngleAxis(frontSensorAngle * sensorDirection, transform.up) * transform.forward;  //so we move 30 degrees to the right

        if (Physics.Raycast(sensorPosition, transform.forward, out hit, sensorLength))
        {
            avoidDirection = 1;
            Debug.DrawLine(sensorPosition, hit.point, Color.black);
        }
        if (Physics.Raycast(sensorPosition, sensorAngle, out hit, sensorLength))
        {
            avoidDirection = 0.5f;
            Debug.DrawLine(sensorPosition, hit.point, Color.black);
        }

        return avoidDirection;      //so this code will be able to detect left and right, through sensordirection and figured its way its needed to go
    }
}

/*         // how i did it before creating the float FrontSideSensors

        //right sensor
        sensorPosition = transform.position + (transform.forward * frontSensor);
        sensorPosition += transform.right * frontSideSensor;

        Vector3 rightAngle = Quaternion.AngleAxis(frontSensorAngle, transform.up) * transform.forward;  //so we move 30 degrees to the right

        if (Physics.Raycast(sensorPosition, transform.forward, out hit, sensorLength))
        {
            avoidDirection = -1;
            Debug.DrawLine(sensorPosition, hit.point, Color.black);
        }
        if (Physics.Raycast(sensorPosition, rightAngle, out hit, sensorLength))
        {
            avoidDirection = -0.5f;
            Debug.DrawLine(sensorPosition, hit.point, Color.black);
        }


        //left sensor
        */