using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class TankHP : MonoBehaviour
{
    public TankData tankData;

    public Slider hp_Slider;
    public float hpValue;
    public Transform fillArea;

    public GameObject tankDieEffect;
    //public AudioClip 


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
        {
            if (transform.root.gameObject.name == "TankFree_Red")
            {
                SceneManager.LoadScene("2.End Scene");
                return;
            }
                

            Destroy(transform.root.gameObject, 0.05f);
            if(!GetComponent<AudioSource>().isPlaying)
                GetComponent<PlayQuickSound>().Play();
            GameObject effect = Instantiate(tankDieEffect, transform.position, transform.rotation);
            Destroy(effect, 0.3f);
        }

        UpdateSliderValue(hpValue);
    }

    public void GetStatus(Status status)
    {
        if(status == Status.Fire)
        {
            GetComponent<MeshRenderer>().material.color = new Color(150.0f, 0.0f, 0.0f);
            for (int i = 0; i < 5; i++)
            {
                transform.GetChild(i).GetComponent<MeshRenderer>().material.color = new Color(150.0f, 0.0f, 0.0f);

                if(i==0)
                    transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material.color = new Color(150.0f, 0.0f, 0.0f);
            }
            
            StartCoroutine(OnFireStatus());
        }
        else if(status == Status.Water)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 150.0f);
            for (int i = 0; i < 5; i++)
            {
                transform.GetChild(i).GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 150.0f);

                if(i==0)
                    transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material.color = new Color(150.0f, 0.0f, 0.0f);
            }
            gameObject.GetComponent<NavMeshAgent>().speed = 0.5f;
        }
        else
        {
            return;
        }
    }

    IEnumerator OnFireStatus()
    {
        while(true){
            yield return new WaitForSeconds(0.2f);
            GetDamage(2);
        }
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
