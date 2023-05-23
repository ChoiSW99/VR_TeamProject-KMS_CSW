using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision coll)
    {
        // 충돌한 객체 정보 출력
        Debug.Log("Collision with: " + coll.gameObject.name);

        // 충돌한 객체의 태그에 따른 동작
        if (coll.gameObject.CompareTag("TANK"))
        {
            // 플레이어와 충돌했을 때 동작
            Debug.Log("Collided with the TANK!");
        }
        else if (coll.gameObject.CompareTag("MAP"))
        {
            // 장애물과 충돌했을 때 동작
            Debug.Log("Collided with an MAP!");
            
            // 폭발 효과
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            GetComponent<PlaySound>().Play();

            this.GetComponent<MeshRenderer>().enabled = false;

            Destroy(explosion, 2.0f);           

            Destroy(this.gameObject, 2.0f);
        }

    }
}
