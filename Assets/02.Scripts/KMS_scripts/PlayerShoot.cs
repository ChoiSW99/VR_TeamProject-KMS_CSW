using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Bomb;

    public Transform ShootEnd;

    public float ShootPower;

    void Start()
    {
        //시작과 동시에 물체가 추락하지 않도록 하기 위한 코드
        GetComponent<Rigidbody>().isKinematic = true;

        ShootPower = 3000f;
    }

    void Shoot()
    {
        //	포탄을 생성
        GameObject BulletInstance = Instantiate(Bomb, ShootEnd.transform.position,
                                                    ShootEnd.transform.rotation) as GameObject;

        //	포탄을 날릴 방향 및 파워 설정
        BulletInstance.GetComponent<Rigidbody>().AddForce(ShootEnd.transform.forward * ShootPower);

        //물체가 여러 물리력을 받도록 허용하는 코드
        //	포탄을 날릴 방향으로 포탄 발사
        BulletInstance.GetComponent<Rigidbody>().isKinematic = false;

        //gameObject.GetComponent<Rigidbody>().AddForce(-ShootEnd.transform.forward * ShootPower);


        Destroy(BulletInstance, 0.2f);
    }
}
