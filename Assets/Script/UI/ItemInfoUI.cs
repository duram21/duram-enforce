using System.Collections;
using System.Runtime.Serialization;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemInfoUI : MonoBehaviour //, IPointerEnterHandler, IPointerExitHandler
{
    public Text itemName;
    public Text itemTier;
    public Image itemIcon;
    public Text itemAttack;
    public Text itemLevel;
    public Text itemDesc;

    void Awake()
    {
        Deinit();   
    }

    public void Init(Item data)
    {
        itemName.text = data.weaponName;
        itemTier.text = "<" + data.weaponTier + ">";
        itemIcon.sprite = data.sprite;
        itemAttack.text = "공격력 : " + data.damage[data.level].ToString();
        itemLevel.text = "Lv." + data.level;
        itemDesc.text = "";

        // 등급별 UI 변경
        switch(data.weaponTier)
        {
            case Item.WeaponTier.Normal:
                itemTier.color = new Color32(0, 60, 255, 255);

                break;

            case Item.WeaponTier.Epic:
                itemTier.color = new Color32(169, 0, 233, 255);

                break;

            case Item.WeaponTier.Legendary:
                itemTier.color = new Color32(255, 240 ,0, 255);

                break;
        }
    }
    public void Deinit()
    {
        itemName.text = "";
        itemTier.text = "";
        itemIcon.sprite = null;
        itemAttack.text = "";
        itemLevel.text = "";
        itemDesc.text = "";
    }
}
