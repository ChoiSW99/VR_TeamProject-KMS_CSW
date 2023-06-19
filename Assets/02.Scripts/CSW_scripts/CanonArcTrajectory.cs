using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonArcTrajectory : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float timeInterval = 0.1f;
    public float maxTime = 5f;
    public float initialVelocity = 10f;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
        DrawTrajectory();
    }

    public void DrawTrajectory()
    {
        lineRenderer.positionCount = Mathf.RoundToInt(maxTime / timeInterval) + 1;

        float currentTime = 0f;
        int index = 0;

        while (currentTime <= maxTime)
        {
            // Calculate the projected position at current time
            Vector3 position = CalculateProjectedPosition(currentTime);

            lineRenderer.SetPosition(index, position);

            currentTime += timeInterval;
            index++;
        }
    }

    private Vector3 CalculateProjectedPosition(float time)
    {
        // Calculate the projectile position at the given time using projectile motion equations
        Vector3 initialPosition = transform.position; // 탱크의 초기 위치
        Vector3 initialVelocityVector = transform.forward * initialVelocity; // 탱크의 초기 속도 벡터

        Vector3 projectedPosition = initialPosition + initialVelocityVector * time + 0.5f * Physics.gravity * time * time;

        return projectedPosition;
    }
}
