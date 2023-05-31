using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Headmove : MonoBehaviour
{
    public InputActionReference joystickInputAction;  // 조이스틱 입력 액션 참조

    private void OnEnable()
    {
        joystickInputAction.action.Enable();
    }

    private void OnDisable()
    {
        joystickInputAction.action.Disable();
    }

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        Vector2 joystickInput = joystickInputAction.action.ReadValue<Vector2>();

        float rotationSpeed = 10f;  // 회전 속도 조절을 위한 값

        float rotationAmount = joystickInput.x * rotationSpeed * Time.deltaTime;  // X축 입력을 기반으로 회전량 계산

        transform.Rotate(Vector3.up, rotationAmount);
    }
}
