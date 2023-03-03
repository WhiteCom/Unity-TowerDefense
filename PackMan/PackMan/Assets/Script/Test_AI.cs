using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_AI : MonoBehaviour
{
    public float speed = 0.0f; // Monster Speed
    public float moveTime = 0.0f; // ���Ͱ� �� �������� �̵��ϴ� �ð�
    public float waitTime = 0.0f; // ���Ͱ� ������ �ٲٱ��� ����ϴ� �ð�

    private float timer; // ���Ͱ� ������ �ٲٰų� �̵��� ������ ���� Ÿ�̸�
    private int direction; // ���Ͱ� �̵��� ����( 0 : ��, 1 : ������, 2 : ����, 4 : �Ʒ��� ) 
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
        Debug.Log("���� ���� : " + direction);

        speed = 2.0f;
        moveTime = 3.0f;
        waitTime = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // ���� �ð����� ������ �ٲٰų� �̵��� ���ߴ� ����
        if(timer > moveTime)
        {
            direction = Random.Range(0, 4); // ������ �������� �ٲ�
            Debug.Log("���� ���� : " + direction);
            timer = 0.0f; // Ÿ�̸� �ʱ�ȭ
        }

        // �̵��ϴ� ����
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
