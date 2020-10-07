using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Turret Script
/*
 * 역할1 : 범위 내에서 가장 가까운 타겟 찾기
 * 역할2 : 타겟이 있으면 해당 방향으로 에임 위치조준(회전)
 * 범위의 경우 OnGizmoSelected 함수를 이용
 */
public class Turret : MonoBehaviour
{
    //일반공격 target, 멀티샷 = target + target2 + target3
    public Transform target;
    private Transform target2;
    private Transform target3;

    private Enemy targetEnemy;
    private Enemy targetEnemy2;
    private Enemy targetEnemy3;

    [Header("General")]

    public float range = 15f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public bool multiShot = false;

    [Header("Use Laser")]
    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowPct = .5f;

    public LineRenderer lineRenderer;
    public Light impactLight;
    public ParticleSystem impactEffect;

    [Header("Use LaserBurst")]
    public bool useLaser2 = false;
    public int damage = 100;
   
    private float attackTime = 7f; //발사 지속 시간
    public float attackTimeCalc = 7f;

    public GameObject LaserEffect;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate; //발사시 회전할 오브젝트(헤드부분)
    public float turnSpeed = 10f;

    public Transform firePoint; //발사지점 (발사체 생성위치)
    
    [Header("FireEffect Setup")]
    public bool Effect_Check = false; //발사시 이펙트 효과 여부
    public GameObject FireEffect;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    //Update문에 쓰지 않는것은, 모든 프레임의 경우에 다 찾아야 한다. 
    //타겟이 없는경우에도 타겟을 찾으려고 하기에, 이는 비효율적 작업. 
    //따라서 메소드를 만들어놓고 몇초뒤에 실행되게 하는 InvokeRepeating을 이용하고자 함.
    void UpdateTarget() //marked enemy
    {
        //적을 찾기전 적에 대한 정보를 가져와야함.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        GameObject secondEnemy = null;
        GameObject thirdEnemy = null;

        //가장 가까운 적 찾는 거리계산용
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            if (multiShot)
            {
                //멀티샷에 타겟팅 될 적들 찾기
                float distancefromEnemy = Vector3.Distance(nearestEnemy.transform.position, enemy.transform.position);
                
                if (distancefromEnemy < 9f)
                {
                    Debug.Log("Second");
                    secondEnemy = enemy;
                }

                float distancefromEnemy2 = Vector3.Distance(secondEnemy.transform.position, enemy.transform.position);

                if (distancefromEnemy2 < 9f)
                {
                    Debug.Log("Third");
                    thirdEnemy = enemy;
                }
            }
        }
        
        //적이 Gizmo범위내에 있을때, 즉 적을 인식했을때
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
            if(multiShot == true)
            {
                target2 = secondEnemy.transform;
                targetEnemy2 = secondEnemy.GetComponent<Enemy>();

                target3 = thirdEnemy.transform;
                targetEnemy3 = thirdEnemy.GetComponent<Enemy>();
            }
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) //적이 없는경우
        {
            if (useLaser) //laser를 사용하면
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }

            }
            //Laser2일때는 계속 발사되는 애니메이션이 있으므로, 중간에 비활성화 하지 않음.
           
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else if (useLaser2)
        {
            //코루틴, Invoke 함수를 사용할경우, 유니티 씬에서 문제가 있어, attackTime을 이용하여, 시간지연을 구현

            Laser2();
            if (attackTime <= 0f)
            {
                LaserStop();
                attackTime = attackTimeCalc;
            }
            attackTime -= Time.deltaTime; 
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        //Target Lock On
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); //y축만 회전되게 
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPct);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void Laser2() //Queen 타워에 쓰일 관통 레이저빔
    {
        
        if (!LaserEffect.activeSelf)
        {
            LaserEffect.SetActive(true);
        }
        

    }

    void LaserStop()
    {
        LaserEffect.SetActive(false);
    }

    void Shoot()
    {
        //일반공격
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (multiShot == true)
        {
            //멀티샷이 활성화되있으면 총알 더 추가
            GameObject bulletGo2 = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet2 = bulletGo2.GetComponent<Bullet>();

            GameObject bulletGo3 = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet3 = bulletGo3.GetComponent<Bullet>();

            if (bullet2 != null)
                bullet2.Seek(target2);

            if (bullet3 != null)
                bullet3.Seek(target3);
        }
        
        if (bullet != null)
        {
            bullet.Seek(target);
        }
            

        if(Effect_Check == true)
        {
            GameObject effectIns = (GameObject)Instantiate(FireEffect, firePoint.position, firePoint.rotation);
            Destroy(effectIns, 3f);
        }
    }

    private void OnDrawGizmosSelected() //Range part
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
