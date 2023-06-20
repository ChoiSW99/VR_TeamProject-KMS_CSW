using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    public float damage; // damage value
    public float explosionRadius; // damage radius
    public Status status; // status type

    public GameObject explosionEffectParticle;

    private void OnCollisionEnter(Collision coll)
    {
        Debug.Log(coll.gameObject.name);
        if(coll.gameObject.tag == "TANK")
        {
            coll.gameObject.GetComponent<TankHP>().GetDamage(damage);

            GameObject explosionEffect = Instantiate(explosionEffectParticle, transform.position, Quaternion.identity);

            Destroy(explosionEffect, 2.0f);

            // explosion sound
            GetComponent<PlaySound>().Play();

            // bomb disappear
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponent<TrailRenderer>().enabled = false;
            
            // bomb destroy
            Destroy(this.gameObject, 2.0f);
        }
        else
            Destroy(this.gameObject);
        //    return; 
        //DamageToTank();
        // instantiate explosion effect
        
    }

    void DamageToTank()
    {
        // 폭발 로직 구현
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            //Debug.Log(collider.gameObject.name);
            if(collider.gameObject.tag == "ENEMY")
            {
                Debug.Log("DamageToTank()");
                collider.gameObject.GetComponent<TankHP>().GetDamage(damage);
                
                collider.gameObject.GetComponent<TankHP>().GetStatus(status);
                //TankStatusChange(collider);
                
            }
        }
    }
}
