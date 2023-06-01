using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTowerTurn : MonoBehaviour
{    
    // OnJoystickMove 스크립트
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
        // OnXValueChange 이벤트에 리스너를 등록합니다.
        joystickMoveScript.OnXValueChange.AddListener(TowerTurn);

        turningState = TowerState.STOP;
    }

    /*private void HandleXValueChange(float xValue)
    {
        // x 값이 변경될 때마다 호출되는 메서드입니다.
        receivedXValue = xValue;

        // 변경된 x 값을 사용하여 다른 처리를 수행합니다.
        Debug.Log("Received X Value: " + receivedXValue);

        // 여기에서 x 값을 활용하여 필요한 동작을 수행할 수 있습니다.
        // 예를 들어, 캐릭터의 이동, 카메라 회전 등을 제어할 수 있습니다.

        BodyTurn(receivedXValue);
    }*/
    /*private void HandleYValueChange(float yValue)
    {
        // y 값이 변경될 때마다 호출되는 메서드입니다.
        receivedYValue = yValue;

        // 변경된 y 값을 사용하여 다른 처리를 수행합니다.
        Debug.Log("Received Y Value: " + receivedYValue);

        // 여기에서 y 값을 활용하여 필요한 동작을 수행할 수 있습니다.
        // 예를 들어, 캐릭터의 이동, 카메라 회전 등을 제어할 수 있습니다.

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

