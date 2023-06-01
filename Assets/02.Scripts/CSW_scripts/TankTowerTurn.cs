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

    // OnJoystickMove 스크립트
    public OnJoystickMove joystickMoveScript;

    private void Start()
    {
        // OnXValueChange 이벤트에 리스너를 등록합니다.
        joystickMoveScript.OnXValueChange.AddListener(HandleXValueChange);
        joystickMoveScript.OnYValueChange.AddListener(HandleYValueChange);

        turningState = TurningState.NO;
    }

    private void HandleXValueChange(float xValue)
    {
        // x 값이 변경될 때마다 호출되는 메서드입니다.
        receivedXValue = xValue;

        // 변경된 x 값을 사용하여 다른 처리를 수행합니다.
        Debug.Log("Received X Value: " + receivedXValue);

        // 여기에서 x 값을 활용하여 필요한 동작을 수행할 수 있습니다.
        // 예를 들어, 캐릭터의 이동, 카메라 회전 등을 제어할 수 있습니다.

        BodyTurn(receivedXValue);
    }
    private void HandleYValueChange(float yValue)
    {
        // y 값이 변경될 때마다 호출되는 메서드입니다.
        receivedYValue = yValue;

        // 변경된 y 값을 사용하여 다른 처리를 수행합니다.
        Debug.Log("Received Y Value: " + receivedYValue);

        // 여기에서 y 값을 활용하여 필요한 동작을 수행할 수 있습니다.
        // 예를 들어, 캐릭터의 이동, 카메라 회전 등을 제어할 수 있습니다.

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

