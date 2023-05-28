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
        // ���⿡�� value.x ���� ����� �� �ֽ��ϴ�.
        Debug.Log("X Value: " + xValue);
    }
}
