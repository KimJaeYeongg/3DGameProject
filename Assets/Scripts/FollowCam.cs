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
        CamTurn();
        // 카메라 x y z 좌표값
        tr.position = Vector3.Lerp(tr.position, targetTr.position + (Vector3.right * x_distance)
            + (Vector3.up * height) + (Vector3.forward * z_distance), dampTrace);
    }

    void CamTurn()
    {
        if(turnBox == 0)
        {
            x_distance = distance;
            z_distance = 0;

            if (camAngle < 270)
                camAngle++;
            else if (camAngle > 270)
                camAngle--;

            tr.rotation = Quaternion.Euler(0, camAngle, 0); 
        }
        else if (turnBox == 1)
        {
            x_distance = 0;
            z_distance = distance;

            if (camAngle < 180)
                camAngle++;
            else if (camAngle > 180)
                camAngle--;
            tr.rotation = Quaternion.Euler(0, camAngle, 0);
        }
        else if (turnBox == 2)
        {
            x_distance = -distance;
            z_distance = 0;

            if (camAngle < 90)
                camAngle++;
            else if (camAngle > 90)
                camAngle--;
            tr.rotation = Quaternion.Euler(0, camAngle, 0);
        }
        else if (turnBox == 3)
        {
            x_distance = 0;
            z_distance = -distance;
            if (camAngle < 0)
                camAngle++;
            else if (camAngle > 0)
                camAngle--;
            tr.rotation = Quaternion.Euler(0, camAngle, 0);
        }
    }
}
