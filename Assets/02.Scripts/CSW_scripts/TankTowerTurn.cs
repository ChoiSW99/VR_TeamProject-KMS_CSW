using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTowerTurn : MonoBehaviour
{    
    // OnJoystickMove ��ũ��Ʈ
    public OnJoystickMove joystickMoveScript;

    //private float receivedXValue;
    //private float receivedYValue;

    public GameObject TankTower;
    //public GameObject TankCanon;

    public float rotationSpeed;

    public TowerState turningState;
    //public CanonState canonState;



    private void Start()
    {
        // OnXValueChange �̺�Ʈ�� �����ʸ� ����մϴ�.
        joystickMoveScript.OnXValueChange.AddListener(TowerTurn);

        turningState = TowerState.STOP;
    }

    /*private void HandleXValueChange(float xValue)
    {
        // x ���� ����� ������ ȣ��Ǵ� �޼����Դϴ�.
        receivedXValue = xValue;

        // ����� x ���� ����Ͽ� �ٸ� ó���� �����մϴ�.
        Debug.Log("Received X Value: " + receivedXValue);

        // ���⿡�� x ���� Ȱ���Ͽ� �ʿ��� ������ ������ �� �ֽ��ϴ�.
        // ���� ���, ĳ������ �̵�, ī�޶� ȸ�� ���� ������ �� �ֽ��ϴ�.

        BodyTurn(receivedXValue);
    }*/
    /*private void HandleYValueChange(float yValue)
    {
        // y ���� ����� ������ ȣ��Ǵ� �޼����Դϴ�.
        receivedYValue = yValue;

        // ����� y ���� ����Ͽ� �ٸ� ó���� �����մϴ�.
        Debug.Log("Received Y Value: " + receivedYValue);

        // ���⿡�� y ���� Ȱ���Ͽ� �ʿ��� ������ ������ �� �ֽ��ϴ�.
        // ���� ���, ĳ������ �̵�, ī�޶� ȸ�� ���� ������ �� �ֽ��ϴ�.

        HeadTurn(receivedYValue);
    }*/

    public void TowerTurn(float received_X)
    {
        Debug.Log("TowerTurn");

        if (received_X > 0)
        {
            turningState = TowerState.RIGHT;
            StartCoroutine(TurnRight());
        }
        else if (received_X < 0)
        {
            turningState = TowerState.LEFT;
            StartCoroutine(TurnLeft());
        }
        else
        {
            turningState = TowerState.STOP;
        }
    }

    // turn right
    private IEnumerator TurnRight()
    {
        while (true)
        {
            TankTower.transform.rotation *= Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f);
            yield return null;

            if (turningState == TowerState.STOP || turningState == TowerState.LEFT)
                yield break;
        }
    }

    // turn left
    private IEnumerator TurnLeft()
    {
        while (true)
        {
            TankTower.transform.rotation *= Quaternion.Euler(0f, -(rotationSpeed * Time.deltaTime), 0f);
            yield return null;

            if (turningState == TowerState.STOP || turningState == TowerState.RIGHT)
                yield break;
        }
    }

    
}

public enum TowerState
{
    STOP = 0,
    RIGHT,
    LEFT,
}

