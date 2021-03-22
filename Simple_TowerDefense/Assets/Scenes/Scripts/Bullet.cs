using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public bool parabola = false; //포물선 움직임

    //Parabola 움직임 위한 변수
    private Vector3 startPos;
    private Vector3 destPos;

    [Space (10f)]
    public float speed = 70f;
    public int damage = 50;
    public float explosionRadius = 0f;

    public GameObject ImpactEffect;

    public void Seek(Transform _target) //chase whatever
    {
        target = _target;
    }

    private void Start()
    {
        if (parabola)
        {
            SetParabolaValue();
        }
        
    }

    void SetParabolaValue()
    {
        startPos = transform.position;
        destPos = target.position;
        
    }
    
    void Update()
    {
        //if we don`t seek target
        //destroy
        if (!parabola && target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        float distanceThisFrame = speed * Time.deltaTime;

        if (!parabola)
        {
            Vector3 dir = target.position - transform.position;
            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            transform.LookAt(target);
        }
        else
        {
            Vector3 dir = destPos - transform.position;
            if(dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            transform.LookAt(destPos);
        }
        
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
      
        Destroy(effectIns, 3.5f);

        if (explosionRadius > 0f)
        {
            Explode(); //function
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
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
            e.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
