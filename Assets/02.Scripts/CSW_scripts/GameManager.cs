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

    public GameObject loadedBombPrefab;

    [Space]
    [Header("HP and Status")]
    [Space]
    public float myHp;
    public Status[] myStatus;

    public GameObject[] bombButtons;
    public int loadedBombNumber;
    private int bombButtonLength;


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
        bombButtonLength = bombButtons.Length;
        
        for (int i=0; i< bombButtonLength; i++)
        {
            TMP_bombs[i].text = remainingBomb[i].ToString();
        }
    }

    public void ChangeBomb_RightGrupBtn()
    {
        if (loadedBombNumber == bombButtonLength - 1) // 마지막 포탄 종류
            loadedBombNumber = 0;
        else
            loadedBombNumber += 1;

        Debug.Log("loadedBombNumber : " + loadedBombNumber);

        ChangeLoadedBomb();
    }

    public void ChangeBomb_LeftGripBtn()
    {
        if (loadedBombNumber == 0) // 첫번째 포탄 종류 
            loadedBombNumber = bombButtonLength-1;
        else
            loadedBombNumber -= 1;

        Debug.Log("loadedBombNumber : " + loadedBombNumber);

        ChangeLoadedBomb();
    }

    private void ChangeLoadedBomb()
    {
        Debug.Log("ChangeLoadedBomb");
        for (int i=0; i< bombButtonLength; i++) // 0 1 2
        {
            if(i == loadedBombNumber) // 
            {
                bombButtons[i].GetComponent<LoadBomb>().BombLoad();
                loadedBombPrefab = bombButtons[i].GetComponent<LoadBomb>().bombPrefab;

                bombButtons[i].GetComponent<PlayQuickSound>().Play();
            }
            else
            {

            }
        }
    }

    
}
