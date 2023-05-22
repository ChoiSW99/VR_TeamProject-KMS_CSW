using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    //탱크의 이동과 속도
    public float moveSpeed = 20.0f;
    public float rotSpeed = 50.0f;

    //참조할 컴포넌트
    private Rigidbody rbody;
    private Transform tr;

    //키보드 입력값 변수
    private float h, v;
    public Transform camPivot;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        rbody.centerOfMass = new Vector3(0.0f, -0.5f, 0.0f); //Rigidbody의 무게 중심을 낮게 설정

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        tr.Rotate(Vector3.up * rotSpeed * h * Time.deltaTime);
        tr.Translate(Vector3.forward * v * moveSpeed * Time.deltaTime);
    }
}
