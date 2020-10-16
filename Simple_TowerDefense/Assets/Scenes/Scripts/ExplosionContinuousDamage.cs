using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionContinuousDamage : MonoBehaviour
{
    [Header ("Explosion Setting")]
    public int explosionDamage = 50; //bullet의 값을 가져와서 쓸 변수
    public float explosionRadius = 25; //bullet의 값을 가져와서 쓸변수

    //지속데미지를 위한 시간변수
    public float DamageTime_Calc = 3f;
    private float DamageTime = 3f;

    void Start()
    {
        DamageTime = DamageTime_Calc;    
    }
    void Update()
    {
        if(DamageTime > 0f)
        {
            Explode();
            DamageTime -= Time.deltaTime;
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(explosionDamage * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
