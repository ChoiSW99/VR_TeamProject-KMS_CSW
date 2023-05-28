using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Bomb")]
    public int num_Normalbomb;
    public int num_Waterbomb;
    public int num_Firebomb;

    public TextMeshProUGUI TMP_Normalbomb;
    public TextMeshProUGUI TMP_Waterbomb;
    public TextMeshProUGUI TMP_Firebomb;

    public GameObject loadedBombPrefab;

    [Space]

    [Header("HP and Status")]
    public float hp;
    public Status[] status;

    public Button[] bombButtons;
    public int loadedBombNumber;


    private void Awake()
    {
        loadedBombNumber = 0;
    }

    public void FireBomb()
    {
        
    }
}
