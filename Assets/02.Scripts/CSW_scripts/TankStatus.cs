using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankStatus : MonoBehaviour
{
    public TankData tankData;

    public Slider hp_Slider;
    public Transform fillArea;
    //float fSliderBarTime;

    private void OnEnable()
    {
        tankData.OnHPValueChanged += UpdateSliderValue;
    }

    private void OnDisable()
    {
        tankData.OnHPValueChanged -= UpdateSliderValue;
    }

    private void UpdateSliderValue(float value)
    {
        hp_Slider.value = value;
    }

    private void Start() {
        if(hp_Slider == null)
            hp_Slider = transform.Find("HP_Slider").GetComponent<Slider>();

        if(fillArea == null)
            fillArea = findAllChildren(hp_Slider.transform, "Fill Area");

        UpdateSliderValue(tankData.hp);
    }

    void Update()
    {
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
