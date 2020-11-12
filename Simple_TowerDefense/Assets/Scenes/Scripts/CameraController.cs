using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [Header("Camera Attribute")]
    public bool Main_Check = true;

    [Space(10f)]
    public Camera Main;
    public Camera Sub1;
    public Camera Sub2;
    public Camera Sub3;
    public Camera Sub4;

    [Space(10f)]
    public Button Main_btn;
    public Button Sub1_btn;
    public Button Sub2_btn;
    public Button Sub3_btn;
    public Button Sub4_btn;

    [Space(10f)]
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    [Space(10f)]
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 85f;

    //숫자 입력 받을 키들
    private KeyCode[] keyCodes =
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
    };

    void Start()
    {
        //초기 카메라는 메인카메라이므로, 버튼 비활성화
        Main_btn.interactable = false;    
    }

    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Main_Check) //메인카메라인 경우
            CameraMove();

        CameraChange();
    }

    public void CameraChange()
    {
        for(int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                int numberPressed = i + 1;
                if (numberPressed == 1) ShowMain();
                else if (numberPressed == 2) ShowSub1();
                else if (numberPressed == 3) ShowSub2();
                else if (numberPressed == 4) ShowSub3();
                else if (numberPressed == 5) ShowSub4();
                Debug.Log(numberPressed);
            }
        }
    }

    public void CameraMove()
    {
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        //스크롤 휠 값은 매우 작으므로 눈에 보이는 변화를 보기 위해 1000을 곱해줌
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }

    public void ShowMain()
    {
        Main.enabled = true;
        Sub1.enabled = false;
        Sub2.enabled = false;
        Sub3.enabled = false;
        Sub4.enabled = false;

        Main_Check = true;

        Main_btn.interactable = false;
        Sub1_btn.interactable = true;
        Sub2_btn.interactable = true;
        Sub3_btn.interactable = true;
        Sub4_btn.interactable = true;
    }

    public void ShowSub1()
    {
        Main.enabled = false;
        Sub1.enabled = true;
        Sub2.enabled = false;
        Sub3.enabled = false;
        Sub4.enabled = false;

        Main_Check = false;

        Main_btn.interactable = true;
        Sub1_btn.interactable = false;
        Sub2_btn.interactable = true;
        Sub3_btn.interactable = true;
        Sub4_btn.interactable = true;
    }

    public void ShowSub2()
    {
        Main.enabled = false;
        Sub1.enabled = false;
        Sub2.enabled = true;
        Sub3.enabled = false;
        Sub4.enabled = false;

        Main_Check = false;

        Main_btn.interactable = true;
        Sub1_btn.interactable = true;
        Sub2_btn.interactable = false;
        Sub3_btn.interactable = true;
        Sub4_btn.interactable = true;
    }

    public void ShowSub3()
    {
        Main.enabled = false;
        Sub1.enabled = false;
        Sub2.enabled = false;
        Sub3.enabled = true;
        Sub4.enabled = false;

        Main_Check = false;

        Main_btn.interactable = true;
        Sub1_btn.interactable = true;
        Sub2_btn.interactable = true;
        Sub3_btn.interactable = false;
        Sub4_btn.interactable = true;
    }

    public void ShowSub4()
    {
        Main.enabled = false;
        Sub1.enabled = false;
        Sub2.enabled = false;
        Sub3.enabled = false;
        Sub4.enabled = true;

        Main_Check = false;

        Main_btn.interactable = true;
        Sub1_btn.interactable = true;
        Sub2_btn.interactable = true;
        Sub3_btn.interactable = true;
        Sub4_btn.interactable = false;
    }
}

