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
        // 충돌한 객체 정보 출력
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
                // 데미지와 상태이상효과 적용
                Debug.Log("collision with map, but close to TANK !, Dist = " + dist);

                // apply status effect
                ApplyStatusEffect(coll);
                ApplyDamage(coll, damage);
            }*/
        }
    }

    // 데미지 적용 메서드
    private void ApplyDamage(Collision coll)
    {
        
        Debug.Log("ApplyDamage to " + coll.gameObject.name);
        // 피격 대상에게 데미지 적용하는 로직 등을 구현
        // ...
    }

    // 상태이상 적용 메서드
    private void ApplyStatusEffect(Collision coll)
    {
        Debug.Log("ApplyStatusEffect to " + coll.gameObject.name);
        // 피격 대상에게 상태이상 적용하는 로직 등을 구현
        // ...
    }

}

