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
        //���۰� ���ÿ� ��ü�� �߶����� �ʵ��� �ϱ� ���� �ڵ�
        GetComponent<Rigidbody>().isKinematic = true;

        ShootPower = 3000f;
    }

    public void Shoot()
    {
        //	��ź�� ����
        GameObject BulletInstance = Instantiate(Bomb, ShootEnd.transform.position,
                                                    ShootEnd.transform.rotation) as GameObject;

        //	��ź�� ���� ���� �� �Ŀ� ����
        BulletInstance.GetComponent<Rigidbody>().AddForce(ShootEnd.transform.forward * ShootPower);

        //��ü�� ���� �������� �޵��� ����ϴ� �ڵ�
        //	��ź�� ���� �������� ��ź �߻�
        BulletInstance.GetComponent<Rigidbody>().isKinematic = false;

        //gameObject.GetComponent<Rigidbody>().AddForce(-ShootEnd.transform.forward * ShootPower);


        Destroy(BulletInstance, 0.2f);
    }
}
