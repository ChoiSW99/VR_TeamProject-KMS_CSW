using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBodyTurnMove : MonoBehaviour
{
    // OnJoystickMove ��ũ��Ʈ
    public OnJoystickMove joystickMoveScript;

    private AudioSource audioSource;
    public PlaySound playSound;

    public GameObject TankBody;
    public float rotationSpeed;

    public BodyState bodyState;
    public float moveSpeed;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // OnXValueChange �̺�Ʈ�� �����ʸ� ����մϴ�.
        joystickMoveScript.OnXValueChange.AddListener(BodyTurn);
        joystickMoveScript.OnYValueChange.AddListener(BodyMove);
        bodyState = BodyState.STOP;
    }

    public void BodyTurn(float received_X)
    {
        if(bodyState == BodyState.TURNING)
            return;

        Debug.Log("BodyTurn received_X " + received_X);

        if (received_X > 0.2f || received_X < -0.2f)
        {
            bodyState = BodyState.MOVING;
            Turn(received_X);
        }
        else
        {
            bodyState = BodyState.STOP;
            audioSource.Stop();
        }
            
    }

    public void BodyMove(float received_Y)
    {
        if(bodyState == BodyState.MOVING)
            return;

        Debug.Log("BodyMove received_Y " + received_Y);

        if (received_Y > 0.2f || received_Y < -0.2f)
        {
            bodyState = BodyState.TURNING;
            Move(received_Y);
        }
        else
        {
            bodyState = BodyState.STOP;
            audioSource.Stop();
        }
            
    }

    // turn right
    private void Turn(float received_X)
    {
        TankBody.transform.rotation *= Quaternion.Euler(0f, rotationSpeed * received_X * Time.deltaTime, 0f);
        audioSource.volume = Mathf.Abs(received_X);
        if(!audioSource.isPlaying)
            playSound.Play();
        return;
    }

    private void Move(float received_Y)
    {
        Debug.Log("Vector3.forward * received_Y * moveSpeed" + Vector3.forward * received_Y * moveSpeed);
        TankBody.transform.Translate(Vector3.forward * received_Y * moveSpeed, Space.Self);
        audioSource.volume = Mathf.Abs(received_Y);
        if(!audioSource.isPlaying)
            playSound.Play();
        return;
    }
}

public enum BodyState
{
    STOP = 0,
    TURNING,
    MOVING
}

