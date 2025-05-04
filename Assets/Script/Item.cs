using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/WeaponData")]
public class Item : ScriptableObject
{
    public enum ItemType {Weapon, Coin}
    public enum WeaponTier {Normal, Epic, Legendary}
    public ItemType itemType;
    
    // weapon Side
    public Sprite sprite;
    public int id;
    public int prefabId;
    public float speed;
    public string weaponName;
    public WeaponTier weaponTier;
    public int level;
    public float[] damage;
    

    // Coin 
}
