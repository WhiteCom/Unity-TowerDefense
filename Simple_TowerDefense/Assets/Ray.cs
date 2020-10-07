using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Ray 스크립트 : Queen타워에서 관통레이저를 쓰기 위해 따로 만드는 스크립트 
 * 최종적으로는 Turret 스크립트 내부에 들어갈것이며, 이를 위해사전에 테스트 하기위한 스크립트.
 * RayCastAll을 이용하여 관통여부 테스트
 * 적을 체크하면 빨간색으로 체크후, 일정시간후 다시 기존 material이 쓰였던 값을 복구함.
 * 해당 부분을 구현하기 위해, 처음엔 Update문에 두개의 시간변수를 두고, 한 특정시간이 되면 색이 변하도록 체크하려고함.
 * 프레임 저하 등 성능문제를 고려하여 코루틴으로 짜기로 방식을 변경. 
 */

public class Ray : MonoBehaviour
{
    RaycastHit[] hits; //Raycast 광선을 쏴서 부딪히는것들 담을 배열
    float MaxDistance = 150f; //Ray의 거리(길이)

    float Time; //경과시간 = 계속 흐름
    float checkTime; //색변화 지정할 시간

    //코루틴 대신 단순 지연을 위해, Invoke 함수를 쓰기 위하여 전역변수로 선언
    MeshRenderer ChangeColor;
    Color origincolor = Color.black;
    RaycastHit hit;

    void Start()
    {
        Time = 0.0f;
        checkTime = 2.0f;
    }
    void Update()
    {
        
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.blue, 0f);
            hits = Physics.RaycastAll(transform.position, transform.forward, MaxDistance);

            for(int i=0; i< hits.Length; i++)
            {
                
                hit = hits[i];

                //swap 기초방식을 이용하여 기존의 material 값을 기억하고있다가, 
                //Ray에 부딪힌 애들은 빨간색 되고, 일정시간후에 다시 원래 색으로 돌아오게 하기
                ChangeColor = hit.transform.GetComponent<MeshRenderer>();
                //origincolor = ChangeColor.material.color;
                if (ChangeColor)
                {
                    hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                    //InvokeRepeating("Rollback_color", 2.0f, .0f);
                    StartCoroutine(Rollback_color(hit));
                }
            }
        }
    }
    /*
    void Rollback_color()
    {
        hit.transform.GetComponent<MeshRenderer>().material.color = origincolor;
    }
    */
    
    //잦은 Update문 호출로 인한 성능저하로 인한 문제를 해결하기 위해 코루틴을 이용
    IEnumerator Rollback_color(RaycastHit hit)
    {
        yield return new WaitForSeconds(1.0f);
        hit.transform.GetComponent<MeshRenderer>().material.color = origincolor;
        //수행할 액션 : 빨간색으로 변경된 이후, 다시 원래 material 색상으로 돌아오도록 구현
    }
    
}
