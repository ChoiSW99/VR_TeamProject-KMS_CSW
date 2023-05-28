using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlaySound))]
public class Bomb : MonoBehaviour
{
    public int damage; // damage value
    public Status status; // status type

    public GameObject explosionEffectParticle;

    private void OnCollisionEnter(Collision coll)
    {
        // instantiate explosion effect
        GameObject explosionEffect = Instantiate(explosionEffectParticle, transform.position, Quaternion.identity);

        Destroy(explosionEffect, 2.0f);

        // explosion sound
        GetComponent<PlaySound>().Play();

        // bomb disappear
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // bomb destroy
        Destroy(this.gameObject, 2.0f);
    }
}

// 상태이상을 나타내는 열거형
public enum Status
{
    None = 0, // None
    Water, // move speed reduction
    Fire // burns

}
