using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ�
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [Header("Bomb")]
    [Space]
    public Slider chargingSlider;
    public float chargingSpeed = 1f; // ���� �ӵ�
    private float currentCharge = 0f; // ���� ���� ����

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
        if (instance == null)   // GameManager �ν��Ͻ��� �����ϰ� ���� �ν��Ͻ��� ���� ��쿡�� �Ҵ�
            instance = this;
        else
            Destroy(gameObject);    // �̹� �ν��Ͻ��� �����ϴ� ���, ���� ��ü�� �ı��Ͽ� �ߺ� ���� ����
    }
    private void OnDestroy()
    {
        if (instance == this)           // �ν��Ͻ��� �ı��� �� ���� �ν��Ͻ��� ����
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
        if (loadedBombNumber == numbombType - 1) // ������ ��ź ����
            loadedBombNumber = 0;
        else
            loadedBombNumber += 1;

        Debug.Log("loadedBombNumber : " + loadedBombNumber);

        ChangeLoadedBomb();
    }

    public void ChangeBomb_LeftGripBtn()
    {
        if (loadedBombNumber == 0) // ù��° ��ź ���� 
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
