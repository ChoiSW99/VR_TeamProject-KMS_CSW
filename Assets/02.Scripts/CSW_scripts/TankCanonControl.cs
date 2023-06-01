using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCanonControl : MonoBehaviour
{
    public OnJoystickMove joystickMoveScript;

    public GameObject TankCanon;
    public float rotationSpeed;
    public CanonState canonState;

    private void Start()
    {
        // OnYValueChange 이벤트에 리스너를 등록합니다.
        joystickMoveScript.OnYValueChange.AddListener(CanonTurn);

        canonState = CanonState.STOP;
    }

    public void CanonTurn(float received_Y)
    {
        Debug.Log("HeadTurn");
        //Debug.Log("BodyTurn(value_x) = " + value_x);

        if (received_Y > 0)
        {
            canonState = CanonState.UP;
            StartCoroutine(CanonUp());
        }
        else if (received_Y < 0)
        {
            canonState = CanonState.DOWN;
            StartCoroutine(CanonDown());
        }
        else
        {
            canonState = CanonState.STOP;
        }
    }

    // Canon Up
    private IEnumerator CanonUp()
    {
        while (true)
        {
            TankCanon.transform.rotation *= Quaternion.Euler(-(rotationSpeed * Time.deltaTime), 0f, 0f );
            yield return null;

            if (canonState == CanonState.STOP || canonState == CanonState.DOWN)
                yield break;
        }
    }

    // Canon Down
    private IEnumerator CanonDown()
    {
        while (true)
        {
            TankCanon.transform.rotation *= Quaternion.Euler((rotationSpeed * Time.deltaTime), 0f, 0f );
            yield return null;

            if (canonState == CanonState.STOP || canonState == CanonState.UP)
                yield break;
        }
    }

}
public enum CanonState
{
    STOP = 0,
    UP,
    DOWN
}