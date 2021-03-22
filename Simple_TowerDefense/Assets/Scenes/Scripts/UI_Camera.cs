using System.Collections;
using UnityEngine;

public class UI_Camera : MonoBehaviour
{
    public Camera MainCam;
    public Camera Sub1Cam;
    public Camera Sub2Cam;
    public Camera Sub3Cam;
    public Camera Sub4Cam;

    [Space(10f)]
    public GameObject MyCanvas;
    private Canvas thisCanvas;

    private Quaternion origitanlRotation;

    void Start()
    {
        thisCanvas = MyCanvas.GetComponent<Canvas>();
        origitanlRotation = transform.rotation;
    }

    void Update()
    {
        Camera_check();
    }

    public void Camera_check()
    {
        if (MainCam.enabled)
        {
            thisCanvas.worldCamera = MainCam; //worldCamera, 시점변경
            transform.rotation = MainCam.transform.rotation * origitanlRotation; //BillBoard 캔버스 구현, 카메라따라 캔버스 움직임
        }
            
        else if (Sub1Cam.enabled)
        {
            thisCanvas.worldCamera = Sub1Cam;
            transform.rotation = Sub1Cam.transform.rotation * origitanlRotation;
        }
            
        else if (Sub2Cam.enabled)
        {
            thisCanvas.worldCamera = Sub2Cam;
            transform.rotation = Sub2Cam.transform.rotation * origitanlRotation;
        }
           
        else if (Sub3Cam.enabled)
        {
            thisCanvas.worldCamera = Sub3Cam;
            transform.rotation = Sub3Cam.transform.rotation * origitanlRotation;
        }
            
        else if (Sub4Cam.enabled)
        {
            thisCanvas.worldCamera = Sub4Cam;
            transform.rotation = Sub4Cam.transform.rotation * origitanlRotation;
        }  
    }
}
