using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
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
    public int[] successRate;
    

    // Coin 
}

[System.Serializable]
public class Item
{
    public ItemSO.ItemType itemType;
    
    // weapon Side
    public Sprite sprite;
    public int id;
    public int prefabId;
    public float speed;
    public string weaponName;
    public ItemSO.WeaponTier weaponTier;
    public int level;
    public float[] damage;
    public int[] successRate;
    

    // Coin

    public Item(ItemSO itemSO)
    {
        this.itemType = itemSO.itemType;
        this.sprite = itemSO.sprite;
        this.id = itemSO.id;
        this.prefabId = itemSO.prefabId;
        this.speed = itemSO.speed;
        this.weaponName = itemSO.weaponName;
        this.weaponTier = itemSO.weaponTier;
        this.level = itemSO.level;
        this.damage = itemSO.damage;
        this.successRate = itemSO.successRate;

    }
}