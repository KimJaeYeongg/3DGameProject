using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandCameraCtrl : MonoBehaviour
{
    private GameObject player;

    public Camera mainCamera;
    public Camera photoCamera;

    public RawImage cameraFilter;

    private GameObject grabPoint;
    private GameObject shootPoint;
    private bool cameraMode;
    private float cameraCoolTime;
    private float curCamCoolTime;

    private void Awake()
    {
        grabPoint = GameObject.FindGameObjectWithTag("EquipPoint");
        shootPoint = GameObject.FindGameObjectWithTag("ShootPoint");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraMode = false;
        cameraCoolTime = 1;
        curCamCoolTime = cameraCoolTime;
        MainCameraView();
    }

    // Update is called once per frame
    void Update()
    {
        CarmeraMode();
    }

    void CarmeraMode()
    {
        if (Input.GetKey(KeyCode.R) && curCamCoolTime <= 0)
        {
            if (!cameraMode)
            {
                this.transform.SetParent(shootPoint.transform);
                this.transform.localPosition = new Vector3(0, (float)-0.125, 0);
                this.transform.rotation = new Quaternion(0, 0, 0, 0);
                this.transform.Rotate(0, 180, 0);
                curCamCoolTime = cameraCoolTime;
                cameraMode = true;
                PhotoCameraView();
            }
            else
            {
                this.transform.SetParent(grabPoint.transform);
                this.transform.localPosition = new Vector3(0, (float)-0.125, 0);
                this.transform.rotation = new Quaternion(0, 0, 0, 0);
                curCamCoolTime = cameraCoolTime;
                cameraMode = false;
                MainCameraView();
            }
        }
        if (curCamCoolTime > 0)
            curCamCoolTime -= Time.deltaTime;
    }

    public void MainCameraView()
    {
        photoCamera.enabled = false;
        mainCamera.enabled = true;
        cameraFilter.enabled = false;
    }

    public void PhotoCameraView()
    {
        photoCamera.enabled = true;
        mainCamera.enabled = false;
        cameraFilter.enabled = true;
    }
}
