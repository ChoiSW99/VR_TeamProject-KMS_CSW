using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int num_Normalbomb;
    public int num_Waterbomb;
    public int num_Firebomb;

    public Button btn_Normalbomb;
    public Button btn_Waterbomb;
    public Button btn_Firebomb;

    public TextMeshProUGUI TMP_Normalbomb;
    public TextMeshProUGUI TMP_Waterbomb;
    public TextMeshProUGUI TMP_Firebomb;

    void Start()
    {
        btn_Normalbomb.onClick.AddListener(UseNormalbomb);
        btn_Waterbomb.onClick.AddListener(UseWaterbomb);
        btn_Firebomb.onClick.AddListener(UseFirebomb);
    }

    void UseNormalbomb()
    {
        if (num_Normalbomb > 0)
        {
            num_Normalbomb--;
            Debug.Log("Used Normal Bomb. Remaining: " + num_Normalbomb);

            TMP_Normalbomb.text = num_Normalbomb.ToString();
        }
        else
        {
            Debug.Log("No Normal Bomb left.");
        }
    }

    void UseWaterbomb()
    {
        if (num_Waterbomb > 0)
        {
            num_Waterbomb--;
            Debug.Log("Used Water Bomb. Remaining: " + num_Waterbomb);
            TMP_Waterbomb.text = num_Waterbomb.ToString();
        }
        else
        {
            Debug.Log("No Water Bomb left.");
        }
    }

    void UseFirebomb()
    {
        if (num_Firebomb > 0)
        {
            num_Firebomb--;
            Debug.Log("Used Fire Bomb. Remaining: " + num_Firebomb);
            TMP_Firebomb.text = num_Firebomb.ToString();
        }
        else
        {
            Debug.Log("No Fire Bomb left.");
        }
    }
}
