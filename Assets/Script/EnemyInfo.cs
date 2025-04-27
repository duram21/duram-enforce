using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "Scriptable Objects/EnemyInfo")]
public class EnemyInfo : ScriptableObject
{
    // 공격 타입
    public enum AttackType {General, Vibrant, Explosive}
    // 수비 타입
    public enum UnitType {Small, Medium, Large} 
    [Header("# Main Info")]
    public string unitName; // 유닛 이름
    public string maxHealth; // 유닛 체력
    public AttackType attackType; // 공격 타입
    public UnitType unitType; // 유닛 타입


    
}
