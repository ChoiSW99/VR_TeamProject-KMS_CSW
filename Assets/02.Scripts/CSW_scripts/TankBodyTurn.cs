using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBodyTurn : MonoBehaviour
{
    private float receivedXValue;

    public GameObject TankBody;
    public float rotationSpeed;

    public TurningState turningState;

    // OnJoystickMove ��ũ��Ʈ
    public OnJoystickMove joystickMoveScript;

    private void Start()
    {
        // OnXValueChange �̺�Ʈ�� �����ʸ� ����մϴ�.
        joystickMoveScript.OnXValueChange.AddListener(HandleXValueChange);

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

    // turn right
    private IEnumerator TurnRight()
    {
        while (true)
        {
            TankBody.transform.rotation *= Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f);
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
            TankBody.transform.rotation *= Quaternion.Euler(0f, -(rotationSpeed * Time.deltaTime), 0f);
            yield return null;

            if (turningState == TurningState.NO || turningState == TurningState.RIGHT)
                yield break;
        }
    }
}

public enum TurningState
{
    NO = 0,
    RIGHT,
    LEFT,
    UP,
    DOWN
}