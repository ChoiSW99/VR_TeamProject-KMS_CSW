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
}