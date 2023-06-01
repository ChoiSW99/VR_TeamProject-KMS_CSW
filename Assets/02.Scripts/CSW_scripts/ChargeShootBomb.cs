using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShootBomb : MonoBehaviour
{
    private GameManager gameManager;
    private int[] remainingBomb;
    private TMPro.TextMeshProUGUI[] TMP_bombs;

    public bool isCharging;

    private void Start()
    {
        gameManager = GameManager.Instance;
        remainingBomb = gameManager.remainingBomb;
        TMP_bombs = gameManager.TMP_bombs;

        isCharging = false;
    }

    public void Charge()
    {
        isCharging = true;
        StartCoroutine(ShootCharging());

    }

    public void Shoot()
    {
        isCharging = false;
        
        if (gameManager.remainingBomb[gameManager.loadedBombNumber] > 0)
        {
            gameManager.remainingBomb[gameManager.loadedBombNumber]--;
            gameManager.TMP_bombs[gameManager.loadedBombNumber].text = gameManager.remainingBomb[gameManager.loadedBombNumber].ToString();
            Debug.Log("Shoot");
        }
        else
            Debug.Log("Not Enough Bomb.");
    }

    private IEnumerator ShootCharging()
    {
        while (isCharging)
        {
            Debug.Log("ShootCharging");
            yield return new WaitForSeconds(0.1f);
        }

        yield break;
    }
}
