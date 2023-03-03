using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Character : MonoBehaviour
{
    public int speed;

    private Rigidbody character_rigidbody;
    private Vector3 character_vector;

    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
        character_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        character_vector.x = Input.GetAxisRaw("Horizontal");
        character_vector.z = Input.GetAxisRaw("Vertical");

        character_rigidbody.velocity = character_vector.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌발생한 오브젝트 : " + collision.transform.name);
    }
}
