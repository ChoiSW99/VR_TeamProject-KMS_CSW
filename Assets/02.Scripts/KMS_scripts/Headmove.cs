using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Headmove : MonoBehaviour
{
    public InputActionReference joystickInputAction;  // ���̽�ƽ �Է� �׼� ����

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

        float rotationSpeed = 10f;  // ȸ�� �ӵ� ������ ���� ��

        float rotationAmount = joystickInput.x * rotationSpeed * Time.deltaTime;  // X�� �Է��� ������� ȸ���� ���

        transform.Rotate(Vector3.up, rotationAmount);
    }
}
