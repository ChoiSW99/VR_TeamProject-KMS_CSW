using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBomb : MonoBehaviour
{
    [Tooltip("position where the bomb is loadede")]  
    public Transform bombLoadTr;

    [Tooltip("which bomb will be loaded")]
    public GameObject bombPrefab; 

    // Load bomb
    public void BombLoad()
    {
        Instantiate(bombPrefab, bombLoadTr.position, bombLoadTr.rotation);
    }
}
