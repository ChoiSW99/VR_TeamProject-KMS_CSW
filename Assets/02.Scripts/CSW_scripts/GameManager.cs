using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Bomb")]
    [Space]
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

    private void Start()
    {
        bombButtonLength = bombButtons.Length;

        for(int i=0; i< bombButtonLength; i++)
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

    public void Shoot()
    {
        if(remainingBomb[loadedBombNumber] > 0)
        {
            remainingBomb[loadedBombNumber]--;
            TMP_bombs[loadedBombNumber].text = remainingBomb[loadedBombNumber].ToString();
            Debug.Log("Shoot");
        }
        else
            Debug.Log("Cannot Shoot Bomb. no more bomb.");
    }
}
