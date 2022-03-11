using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    const float sensorLength = 5;   //max distance
    const float frontSensor = 1;    //starting point of the front sensor


    public void Check()
    {
        Vector3 sensorPosition;
        RaycastHit hit;     //checks if we hit something, and the angle since there are multiple sensors
        bool flag;
        float avoidDirection;   //direction we will need to avoid to


        sensorPosition = transform.position + (transform.forward * frontSensor);
        if (Physics.Raycast(sensorPosition, transform.forward, out hit, sensorLength))
        {
            if(hit.normal.x < 0)
            {
                avoidDirection = -1; //-1 will take it to the left <=
            }
            else
            {
                avoidDirection = 1; //vice versa
            }
            Debug.DrawLine(transform.position, hit.point, Color.red);
        }



    }
}
