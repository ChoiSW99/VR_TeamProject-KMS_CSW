using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{
    public Transform target;

    NavMeshAgent nav;
    

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 20f;
    public float fireRate = 2.0f;
    private float nextFire;

    public GameObject tankHead;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        tankHead.transform.LookAt(target);
        if(Vector3.Distance(this.gameObject.transform.position, target.position) >= 40.0f)
        {
            nav.speed = 3.0f;
            nav.SetDestination(target.position);
        }
        else{
            nav.speed = 0.0f;
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Fire();
            }
        }
    }

    void Fire()
    {
        // 총알 프리팹 생성
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // 총알 발사
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // 2초 뒤에 파괴
        Destroy(bullet, 2.0f);
    }
}
