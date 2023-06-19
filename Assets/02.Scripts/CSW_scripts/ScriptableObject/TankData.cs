using UnityEngine;

[CreateAssetMenu(fileName = "TankData", menuName = "TankInfo/Tank")]
public class TankData : ScriptableObject
{
    [SerializeField]
    public float hp;

    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    public Status[] status;

    public event System.Action<float> OnHPValueChanged;

    public void SetGaugeValue(float value)
    {
        hp = value;
        OnHPValueChanged?.Invoke(value);
    }
}