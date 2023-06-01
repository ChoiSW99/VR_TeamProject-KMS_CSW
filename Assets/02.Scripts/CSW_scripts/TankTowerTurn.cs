using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTowerTurn : MonoBehaviour
{
    private float receivedXValue;
    private float receivedYValue;

    public GameObject TankHead;
    public float rotationSpeed;

    public TurningState turningState;

    // OnJoystickMove ��ũ��Ʈ
    public OnJoystickMove joystickMoveScript;

    private void Start()
    {
        // OnXValueChange �̺�Ʈ�� �����ʸ� ����մϴ�.
        joystickMoveScript.OnXValueChange.AddListener(HandleXValueChange);
        joystickMoveScript.OnYValueChange.AddListener(HandleYValueChange);

        turningState = TurningState.NO;
    }

    private void HandleXValueChange(float xValue)
    {
        // x ���� ����� ������ ȣ��Ǵ� �޼����Դϴ�.
        receivedXValue = xValue;

        // ����� x ���� ����Ͽ� �ٸ� ó���� �����մϴ�.
        Debug.Log("Received X Value: " + receivedXValue);

        // ���⿡�� x ���� Ȱ���Ͽ� �ʿ��� ������ ������ �� �ֽ��ϴ�.
        // ���� ���, ĳ������ �̵�, ī�޶� ȸ�� ���� ������ �� �ֽ��ϴ�.

        BodyTurn(receivedXValue);
    }
    private void HandleYValueChange(float yValue)
    {
        // y ���� ����� ������ ȣ��Ǵ� �޼����Դϴ�.
        receivedYValue = yValue;

        // ����� y ���� ����Ͽ� �ٸ� ó���� �����մϴ�.
        Debug.Log("Received Y Value: " + receivedYValue);

        // ���⿡�� y ���� Ȱ���Ͽ� �ʿ��� ������ ������ �� �ֽ��ϴ�.
        // ���� ���, ĳ������ �̵�, ī�޶� ȸ�� ���� ������ �� �ֽ��ϴ�.

        HeadTurn(receivedYValue);
    }

    public void BodyTurn(float _receivedXValue)
    {
        Debug.Log("BodyTurn");
        //Debug.Log("BodyTurn(value_x) = " + value_x);

        if (_receivedXValue > 0)
        {
            turningState = TurningState.RIGHT;
            StartCoroutine(TurnRight());
        }
        else if (_receivedXValue < 0)
        {
            turningState = TurningState.LEFT;
            StartCoroutine(TurnLeft());
        }
        else
        {
            turningState = TurningState.NO;
        }
    }

    public void HeadTurn(float _receivedYValue)
    {
        Debug.Log("HeadTurn");
        //Debug.Log("BodyTurn(value_x) = " + value_x);

        if (_receivedYValue > 0)
        {
            turningState = TurningState.UP;
            StartCoroutine(TurnUp());
        }
        else if (_receivedYValue < 0)
        {
            turningState = TurningState.DOWN;
            StartCoroutine(TurnDown());
        }
        else
        {
            turningState = TurningState.NO;
        }
    }

    // turn right
    private IEnumerator TurnRight()
    {
        while (true)
        {
            TankHead.transform.rotation *= Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f);
            yield return null;

            if (turningState == TurningState.NO || turningState == TurningState.LEFT)
                yield break;
        }
    }

    // turn left
    private IEnumerator TurnLeft()
    {
        while (true)
        {
            TankHead.transform.rotation *= Quaternion.Euler(0f, -(rotationSpeed * Time.deltaTime), 0f);
            yield return null;

            if (turningState == TurningState.NO || turningState == TurningState.RIGHT)
                yield break;
        }
    }

    // turn up
    private IEnumerator TurnUp()
    {
        while (true)
        {
            TankHead.transform.rotation *= Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f);
            yield return null;

            if (turningState == TurningState.NO || turningState == TurningState.DOWN)
                yield break;
        }
    }

    // turn down
    private IEnumerator TurnDown()
    {
        while (true)
        {
            TankHead.transform.rotation *= Quaternion.Euler(0f, -(rotationSpeed * Time.deltaTime), 0f);
            yield return null;

            if (turningState == TurningState.NO || turningState == TurningState.UP)
                yield break;
        }
    }
}

