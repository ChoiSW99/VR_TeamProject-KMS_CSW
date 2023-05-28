using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMoveTest : MonoBehaviour
{
    private OnJoystickMove joystickMoveScript;

    private void Awake()
    {
        joystickMoveScript = GetComponent<OnJoystickMove>();
        joystickMoveScript.OnXValueChange.AddListener(HandleXValueChange);
        joystickMoveScript.OnXValueChange.AddListener(HandleXValueChange);
    }

    private void OnDestroy()
    {
        joystickMoveScript.OnXValueChange.RemoveListener(HandleXValueChange);
    }

    private void HandleXValueChange(float xValue)
    {
        // 여기에서 value.x 값을 사용할 수 있습니다.
        Debug.Log("X Value: " + xValue);
    }
}
