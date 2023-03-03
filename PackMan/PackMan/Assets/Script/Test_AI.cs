using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_AI : MonoBehaviour
{
    public float speed = 0.0f; // Monster Speed
    public float moveTime = 0.0f; // 몬스터가 한 방향으로 이동하는 시간
    public float waitTime = 0.0f; // 몬스터가 방향을 바꾸기전 대기하는 시간

    private float timer; // 몬스터가 방향을 바꾸거나 이동을 멈췄을 때의 타이머
    private int direction; // 몬스터가 이동할 방향( 0 : 위, 1 : 오른쪽, 2 : 왼쪽, 4 : 아래쪽 ) 
    private Vector3 moveVector;

    private int minX;
    private int minZ;
    private int maxX;
    private int maxZ;

    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(0, 4);
        moveVector = Vector3.zero;
        Debug.Log("시작 방향 : " + direction);

        speed = 2.0f;
        moveTime = 3.0f;
        waitTime = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // 일정 시간마다 방향을 바꾸거나 이동을 멈추는 로직
        if(timer > moveTime)
        {
            direction = Random.Range(0, 4); // 방향을 랜덤으로 바꿈
            Debug.Log("변경 방향 : " + direction);
            timer = 0.0f; // 타이머 초기화
        }

        // 이동하는 로직
        switch(direction)
        {
            case 0:
                moveVector = Vector3.up;
                break;

            case 1:
                moveVector = Vector3.right;
                break;

            case 2:
                moveVector = Vector3.left;
                break;

            case 3:
                moveVector = Vector3.down;
                break;
        }

        transform.Translate(moveVector * speed * Time.deltaTime);
    }
}
