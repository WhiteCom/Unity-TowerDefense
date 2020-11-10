using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    public GameObject Laser; //2초뒤 발사되는 진짜 레이저

    private float MaxDistance = 75f; //Ray 길이
    private int damage = 100;
    private Transform firePoint; //turret에서 가져와서 쓸것들
   
    public Turret turret;
    private LineRenderer LaserBeam;

    void Start()
    {
        MaxDistance = turret.range; //기존 터렛에 있는 Gizmo범위와 동일하게 하고자 함.
        damage = turret.damage;
        firePoint = turret.firePoint;

        LaserBeam = Laser.GetComponent<LineRenderer>();
        LaserBeam.enabled = false;
    }

    void Update()
    {
        if (LaserBeam.enabled)
        {
            RaycastHit[] hits; //Ray를 쏴서 부딪힐 대상들
            
            hits = Physics.RaycastAll(firePoint.position, firePoint.forward, MaxDistance);
            Debug.DrawRay(firePoint.position, firePoint.forward * MaxDistance, Color.blue, 0.01f);

            foreach(RaycastHit hit in hits)
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    //제대로 되는지 테스트
                    //hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                    hit.transform.GetComponent<Enemy>().TakeDamage(damage * Time.deltaTime);
                }
            }
            
        }
    }
}
