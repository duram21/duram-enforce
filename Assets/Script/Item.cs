using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/WeaponData")]
public class Item : ScriptableObject
{
    public enum ItemType {Weapon}
    public ItemType itemType;
    public Sprite sprite;
    public int id;
    public int prefabId;
    public float damage;
    public float speed;
    public string weaponName;
    public enum WeaponTier {normal, epic, legendary}
    public WeaponTier weaponTier;
}
