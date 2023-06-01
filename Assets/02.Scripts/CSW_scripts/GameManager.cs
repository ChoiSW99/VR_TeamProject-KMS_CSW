using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [Header("Bomb")]
    [Space]
    public Slider chargingSlider;
    public float chargingSpeed = 1f; // 충전 속도
    private float currentCharge = 0f; // 현재 충전 상태

    public int[] remainingBomb;

    public TextMeshProUGUI[] TMP_bombs;

    public GameObject loadedBomb;

    [Space]
    [Header("HP and Status")]
    [Space]
    public float myHp;
    public Status[] myStatus;

    public GameObject[] bombType;
    public Image[] bombImg;
    public int loadedBombNumber;
    private int numbombType;

    private void Awake()
    {
        if (instance == null)   // GameManager 인스턴스를 생성하고 현재 인스턴스가 없을 경우에만 할당
            instance = this;
        else
            Destroy(gameObject);    // 이미 인스턴스가 존재하는 경우, 현재 객체를 파괴하여 중복 생성 방지
    }
    private void OnDestroy()
    {
        if (instance == this)           // 인스턴스가 파괴될 때 현재 인스턴스를 해제
            instance = null;
    }

    private void Start()
    {
        numbombType = bombType.Length;
        
        for (int i=0; i< numbombType; i++)
        {
            TMP_bombs[i].text = remainingBomb[i].ToString();
        }

        ChangeBombImgAlpha();
    }

    public void ChangeBomb_RightGrupBtn()
    {
        if (loadedBombNumber == numbombType - 1) // 마지막 포탄 종류
            loadedBombNumber = 0;
        else
            loadedBombNumber += 1;

        Debug.Log("loadedBombNumber : " + loadedBombNumber);

        ChangeLoadedBomb();
    }

    public void ChangeBomb_LeftGripBtn()
    {
        if (loadedBombNumber == 0) // 첫번째 포탄 종류 
            loadedBombNumber = numbombType-1;
        else
            loadedBombNumber -= 1;

        Debug.Log("loadedBombNumber : " + loadedBombNumber);

        ChangeLoadedBomb();
    }

    private void ChangeLoadedBomb()
    {
        Debug.Log("ChangeLoadedBomb");
        for (int i=0; i< numbombType; i++) // 0 1 2
        {
            if(i == loadedBombNumber) 
            {
                loadedBomb = bombType[i].GetComponent<BombType>().bombPrefab;

                bombType[i].GetComponent<PlayQuickSound>().Play();
            }
            else
            {

            }
        }

        ChangeBombImgAlpha();
    }

    private void ChangeBombImgAlpha()
    {
        Debug.Log("ChangeLoadedBomb");
        for (int i = 0; i < numbombType; i++) // 0 1 2
        {
            if (i == loadedBombNumber)
            {
                bombImg[i].color = new Color(bombImg[i].color.r, bombImg[i].color.g, bombImg[i].color.b, 1.0f);
            }
            else
            {
                bombImg[i].color = new Color(bombImg[i].color.r, bombImg[i].color.g, bombImg[i].color.b, 150.0f / 255.0f);
            }
        }
    }


}
