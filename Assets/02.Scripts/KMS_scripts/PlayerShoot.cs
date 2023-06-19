using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private GameManager gameManager;
    private int[] remainingBomb;
    private TMPro.TextMeshProUGUI[] TMP_bombs;

    public GameObject Bomb;

    public Transform ShootEnd;

    public float ShootPower;

    void Start()
    {
        gameManager = GameManager.Instance;
        remainingBomb = gameManager.remainingBomb;
        TMP_bombs = gameManager.TMP_bombs;

        //���۰� ���ÿ� ��ü�� �߶����� �ʵ��� �ϱ� ���� �ڵ�
        //GetComponent<Rigidbody>().isKinematic = true;

        ShootPower = 3000f;
    }

    public void Shoot()
    {
        Debug.Log("gameManager.loadedBombNumber : " + gameManager.loadedBombNumber);
        if (gameManager.remainingBomb[gameManager.loadedBombNumber] > 0)
        {
            Bomb = gameManager.bombType[gameManager.loadedBombNumber].GetComponent<BombType>().bombPrefab;

            gameManager.remainingBomb[gameManager.loadedBombNumber]--;
            gameManager.TMP_bombs[gameManager.loadedBombNumber].text = gameManager.remainingBomb[gameManager.loadedBombNumber].ToString();

            //	��ź�� ����
            GameObject BulletInstance = Instantiate(Bomb, ShootEnd.transform.position,
                                                    ShootEnd.transform.rotation) as GameObject;

            //	��ź�� ���� ���� �� �Ŀ� ����
            BulletInstance.GetComponent<Rigidbody>().AddForce(ShootEnd.transform.forward * ShootPower);

            //��ü�� ���� �������� �޵��� ����ϴ� �ڵ�
            //	��ź�� ���� �������� ��ź �߻�
            BulletInstance.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
            Debug.Log("Not Enough Bomb.");
        

        //gameObject.GetComponent<Rigidbody>().AddForce(-ShootEnd.transform.forward * ShootPower);


        //Destroy(BulletInstance, 0.2f);
    }
}
