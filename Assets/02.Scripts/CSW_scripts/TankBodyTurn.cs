using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBodyTurn : MonoBehaviour
{
    // OnJoystickMove ��ũ��Ʈ
    public OnJoystickMove joystickMoveScript;
    //private float receivedXValue;

    public GameObject TankBody;
    public float rotationSpeed;

    public TurningState_Body turningState;



    private void Start()
    {
        // OnXValueChange �̺�Ʈ�� �����ʸ� ����մϴ�.
        joystickMoveScript.OnXValueChange.AddListener(BodyTurn);

        turningState = TurningState_Body.STOP;
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


    public void BodyTurn(float received_X)
    {
        Debug.Log("BodyTurn");

        if (received_X > 0)
        {
            turningState = TurningState_Body.RIGHT;
            StartCoroutine(TurnRight());
        }
        else if (received_X < 0)
        {
            turningState = TurningState_Body.LEFT;
            StartCoroutine(TurnLeft());
        }
        else
        {
            turningState = TurningState_Body.STOP;
        }
    }

    // turn right
    private IEnumerator TurnRight()
    {
        while (true)
        {
            TankBody.transform.rotation *= Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f);
            yield return null;

            if (turningState == TurningState_Body.STOP || turningState == TurningState_Body.LEFT)
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

            if (turningState == TurningState_Body.STOP || turningState == TurningState_Body.RIGHT)
                yield break;
        }
    }
}

public enum TurningState_Body
{
    STOP = 0,
    RIGHT,
    LEFT,
}

