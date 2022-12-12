using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HandCameraCtrl : MonoBehaviour
{
    private GameObject player;

    public Inventory inventory;

    public Camera mainCamera;
    public Camera photoCamera;

    public RawImage cameraFilter;
    public Image photoButton;
    public GameObject photoBook;

    private GameObject grabPoint;
    private GameObject shootPoint;

    private bool cameraMode;
    private float cameraCoolTime;
    private float curCamCoolTime;

    private float xRotate, yRotate, xRotateMove, yRotateMove;
    public float rotateSpeed = 100.0f;
    private bool initRot = true;

    //Fade ==================================================

    public float animTime = 0.5f;         // Fade 애니메이션 재생 시간 (단위:초).  
    public Image fadeImage;            // UGUI의 Image컴포넌트 참조 변수.  

    private float start = 1f;           // Mathf.Lerp 메소드의 첫번째 값.  
    private float end = 0f;             // Mathf.Lerp 메소드의 두번째 값.  
    private float time = 0f;            // Mathf.Lerp 메소드의 시간 값.  

    public bool stopIn = true; //false일때 실행되는건데, 초기값을 false로 한 이유는 게임 시작할때 페이드인으로 들어가려고...그게 싫으면 true로 하면됨.
    public bool stopOut = true;

    //=======================================================

    [SerializeField]
    LayerMask layerMask;

    private bool textActivate;
    public Text itemText;
    public Text clickToTakePictureText;

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
        cameraCoolTime = 3;
        curCamCoolTime = cameraCoolTime;
        textActivate = false;
        MainCameraView();
    }

    // Update is called once per frame
    void Update()
    {
        CarmeraMode();
        RotateCamera();
        TryTakePicture();
        SetTextActivation();
    }

    void CarmeraMode()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!cameraMode)
            {
                this.transform.SetParent(shootPoint.transform);
                this.transform.localPosition = new Vector3(0, (float)-0.125, 0);
                this.transform.rotation = new Quaternion(0, 0, 0, 0);
                this.transform.Rotate(0, 180, 0);
                cameraMode = true;
                initRot = true;
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
    }

    public void MainCameraView()
    {
        photoCamera.enabled = false;
        mainCamera.enabled = true;
        cameraFilter.enabled = false;
        Cursor.visible = true;
        photoButton.enabled = true;
    }

    public void PhotoCameraView()
    {
        photoCamera.enabled = true;
        mainCamera.enabled = false;
        cameraFilter.enabled = true;
        Cursor.visible = false;
        photoButton.enabled = false;
        photoBook.SetActive(false);
    }

    public void RotateCamera()
    {
        if(cameraMode)
        {
            if(initRot)
            {
                xRotate = 0;
                yRotate = 180 + player.transform.eulerAngles.y;
                initRot = false;
            }    

            xRotateMove = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
            yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;


            yRotate = yRotate + yRotateMove;
            xRotate = xRotate + xRotateMove;

            xRotate = Mathf.Clamp(xRotate, -90, 90); // 위, 아래 고정
            yRotate = Mathf.Clamp(yRotate, 90 + player.transform.eulerAngles.y, 270 + player.transform.eulerAngles.y);
            
            transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        }
    }

    public void TryTakePicture()
    {
        
        if(cameraMode)
        {
            ScanItem();
            if (Input.GetMouseButtonDown(0) && curCamCoolTime <= 0)
            {
                TakeShot();
                curCamCoolTime = cameraCoolTime;
                StartCoroutine(this.PlayFadeIn());
            }
        }

        if (curCamCoolTime > 0)
            curCamCoolTime -= Time.deltaTime;
    }

    public void TakeShot()
    {
        Debug.DrawRay(this.transform.position, -transform.forward * 10, Color.red, 1f);

        RaycastHit hit;

        if(Physics.Raycast(this.transform.position, -transform.forward, out hit, 100f, layerMask))
        {
            GameObject itemObject = hit.collider.gameObject;
            Item item = itemObject.GetComponent<Item>();

            if (inventory.AddItem(item))
            {
                if(item.GetItemName() != "Cloud" && item.GetItemName() != "Mushroom")
                    itemObject.SetActive(false);
                Debug.Log("Item Successfully Added!");
            }
        }
    }

    public void ScanItem()
    {
        RaycastHit hit;

        if (Physics.Raycast(this.transform.position, -transform.forward, out hit, 100f, layerMask))
        {
            textActivate = true;
            Item item = hit.collider.gameObject.GetComponent<Item>();
            itemText.text = "<color=#ff0000>" + item.GetItemName() + "</color>";
        }
        else
            textActivate = false;
    }

    public void SetTextActivation()
    {
        if(cameraMode && textActivate)
        {
            itemText.enabled = true;
            clickToTakePictureText.enabled = true;
        }
        else
        {
            itemText.enabled = false;
            clickToTakePictureText.enabled = false;
        }
    }

    IEnumerator PlayFadeIn()
    {
        while (true)
        {
            if(time >= animTime)
            {
                time = 0;
                yield break;
            }

            time += Time.deltaTime / animTime;
            Color color = fadeImage.color;
            color.a = Mathf.Lerp(start, end, time);
            fadeImage.color = color;

            yield return null;
        }
    }

    public bool getCamMode() { return cameraMode; }
}
