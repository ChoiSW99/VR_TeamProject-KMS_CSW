using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 5.5f, -8);

    }
}
