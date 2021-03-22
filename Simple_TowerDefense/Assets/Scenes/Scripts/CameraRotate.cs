using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private float panSpeed = 15.0f;
    GameObject child;

    void Start()
    {
        child = transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (child.activeInHierarchy)
            CameraRotation();
    }

    public void CameraRotation()
    {
        //Sub 카메라들 카메라 회전용 
        Vector3 angle = new Vector3(0, 0, 0);

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            angle.y += Time.deltaTime * panSpeed;
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            angle.y -= Time.deltaTime * panSpeed;
        }
        transform.Rotate(angle, Space.Self);
    }
}
