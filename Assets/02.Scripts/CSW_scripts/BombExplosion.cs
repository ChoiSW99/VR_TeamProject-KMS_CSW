using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision coll)
    {
        // �浹�� ��ü ���� ���
        Debug.Log("Collision with: " + coll.gameObject.name);

        // �浹�� ��ü�� �±׿� ���� ����
        if (coll.gameObject.CompareTag("TANK"))
        {
            // �÷��̾�� �浹���� �� ����
            Debug.Log("Collided with the TANK!");
        }
        else if (coll.gameObject.CompareTag("MAP"))
        {
            // ��ֹ��� �浹���� �� ����
            Debug.Log("Collided with an MAP!");
            
            // ���� ȿ��
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            GetComponent<PlaySound>().Play();

            this.GetComponent<MeshRenderer>().enabled = false;

            Destroy(explosion, 2.0f);           

            Destroy(this.gameObject, 2.0f);
        }

    }
}
