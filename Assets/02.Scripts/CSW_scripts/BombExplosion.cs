using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public int damage; // damage value
    public Status status; // status type

    private void Start()
    {
        //damage = this.gameObject.GetComponent<Bomb>().damage;
        //status = this.gameObject.GetComponent<Bomb>().status;
    }

    private void OnCollisionEnter(Collision coll)
    {
        // �浹�� ��ü ���� ���
        Debug.Log("Collision with: " + coll.gameObject.name);

        if (coll.gameObject.CompareTag("TANK"))
        {
            Debug.Log("Collided with TANK!");

            ApplyDamage(coll); 
            ApplyStatusEffect(coll);
            

        }
        else if (coll.gameObject.CompareTag("MAP"))
        {
            Debug.Log("Collided with an MAP!");

            /*float dist = Vector3.Distance(this.transform.position, coll.transform.position);

            // collision with map, but close to tank
            if (dist <= 3.0f)
            {
                // �������� �����̻�ȿ�� ����
                Debug.Log("collision with map, but close to TANK !, Dist = " + dist);

                // apply status effect
                ApplyStatusEffect(coll);
                ApplyDamage(coll, damage);
            }*/
        }
    }

    // ������ ���� �޼���
    private void ApplyDamage(Collision coll)
    {
        
        Debug.Log("ApplyDamage to " + coll.gameObject.name);
        // �ǰ� ��󿡰� ������ �����ϴ� ���� ���� ����
        // ...
    }

    // �����̻� ���� �޼���
    private void ApplyStatusEffect(Collision coll)
    {
        Debug.Log("ApplyStatusEffect to " + coll.gameObject.name);
        // �ǰ� ��󿡰� �����̻� �����ϴ� ���� ���� ����
        // ...
    }

}

