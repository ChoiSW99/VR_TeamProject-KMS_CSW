using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHP : MonoBehaviour
{
    public TankData tankData;

    public Slider hp_Slider;
    public float hpValue;
    public Transform fillArea;

    private void Start()
    {
        if (hp_Slider == null)
            hp_Slider = transform.Find("HP_Slider").GetComponent<Slider>();

        if (fillArea == null)
            fillArea = findAllChildren(hp_Slider.transform, "Fill Area");

        hpValue = tankData.hp;

        UpdateSliderValue(hpValue);
    }

    public void GetDamage(float value)
    {
        hpValue -= value;
        if(hpValue <= 0.0f)
            Destroy(transform.root.gameObject, 0.3f);

        UpdateSliderValue(hpValue);
    }

    private void UpdateSliderValue(float value)
    {
        hp_Slider.value = value;

        if (hp_Slider.value <= 0)
            fillArea.gameObject.SetActive(false);
        else
            fillArea.gameObject.SetActive(true);
    }

    private Transform findAllChildren(Transform tr, string finding)
    {
        Transform[] allChildren = tr.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if(child.name == finding)
                return child;
        }

        return null;
    }

}
