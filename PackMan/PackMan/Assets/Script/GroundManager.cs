using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public static GroundManager instance;
    public TileSc[] tileObjects;

    public GameObject map;

    public int tileX_length;
    public int tileZ_length;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("�̹� �����ϴ� GroundManager �Դϴ�!");
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void init()
    {
        if(map == null)
        {
            Debug.Log("Map�� �����ϴ�! ���� �־��ּ���!");
            return;
        }

        tileX_length = 15;
        tileZ_length = 7;
    }

}

