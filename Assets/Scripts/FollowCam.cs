using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    public Vector3 offset;

    public float height = 2.0f;
    public float distance = 5.0f;
    public float dampTrace = 0.8f;
    public float camAngle = 270;
    public float camAngleSpeed = 5.0f;

    public int turnBox = 0;

    private Transform tr;
    private float x_distance;
    private float z_distance;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        x_distance = distance;
        z_distance = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
      
        // 카메라 x y z 좌표값
        tr.position = Vector3.Lerp(tr.position, targetTr.position + (Vector3.right * x_distance)
            + (Vector3.up * height) + (Vector3.forward * z_distance), dampTrace);
    }

    void FixedUpdate()
    {
        CamTurn();
    }

    void CamTurn()
    {
        if(turnBox == 0)
        {
            if (camAngle == 0)
                camAngle = 360;

            //x_distance = distance;
            //z_distance = 0;

            if (camAngle < 270)
            {
                camAngle += camAngleSpeed;
                if (x_distance < distance)
                    x_distance += distance / 90 * camAngleSpeed;
                if (z_distance > 0)
                    z_distance -= distance / 90 * camAngleSpeed;
            }
            else if (camAngle > 270)
            {
                camAngle -= camAngleSpeed;
                if (x_distance < distance)
                    x_distance += distance / 90 * camAngleSpeed;
                if (z_distance < 0)
                    z_distance += distance / 90 * camAngleSpeed;
            }
        }
        else if (turnBox == 1)
        {
            //x_distance = 0;
            //z_distance = distance;

            if (camAngle < 180)
            {
                camAngle += camAngleSpeed;
                if (z_distance < distance)
                    z_distance += distance / 90 * camAngleSpeed;
                if (x_distance < 0)
                    x_distance += distance / 90 * camAngleSpeed;
            }
            else if (camAngle > 180)
            {
                camAngle -= camAngleSpeed;
                if (z_distance < distance)
                    z_distance += distance / 90 * camAngleSpeed;
                if (x_distance > 0)
                    x_distance -= distance / 90 * camAngleSpeed;
            }
        }
        else if (turnBox == 2)
        {
            //x_distance = -distance;
            //z_distance = 0;

            if (camAngle < 90)
            {
                camAngle += camAngleSpeed;

                if (x_distance > -distance)
                    x_distance -= distance / 90 * camAngleSpeed;
                if (z_distance < 0)
                    z_distance += distance / 90 * camAngleSpeed;
            }
            else if (camAngle > 90)
            {
                camAngle -= camAngleSpeed;
                if (x_distance > -distance)
                    x_distance -= distance / 90 * camAngleSpeed;
                if (z_distance > 0)
                    z_distance -= distance / 90 * camAngleSpeed;
            }
        }
        else if (turnBox == 3)
        {
            if (camAngle == 270)
                camAngle = -90;
            //x_distance = 0;
            //z_distance = -distance;

            if (camAngle < 0)
            {
                camAngle += camAngleSpeed;

                if (z_distance > -distance)
                    z_distance -= distance / 90 * camAngleSpeed;
                if(x_distance > 0)
                    x_distance -= distance / 90 * camAngleSpeed; 
            }
            else if (camAngle > 0)
            {
                
                camAngle -= camAngleSpeed;
                if (z_distance > -distance)
                    z_distance -= distance / 90 * camAngleSpeed;
                if (x_distance < 0)
                    x_distance += distance / 90 * camAngleSpeed;
            }
        }

        
            tr.rotation = Quaternion.Euler(0, camAngle, 0);
    }
}
