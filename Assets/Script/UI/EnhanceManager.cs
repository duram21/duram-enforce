using NUnit.Framework;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class EnhanceManager : MonoBehaviour
{
    public static EnhanceManager Instance { get; private set; }
    public Text itemName;
    public Image background;
    public Image icon;
    public Text textLevel;
    public Text textCur;
    public Text textNext;
    public Text textRate;
    [SerializeField] public Item item;
    public DraggableUI draggableUI;
    public bool isMax;

    void Awake()
    {
        Instance = this;
        Deinit();
    }

    
    public void Init(Item item)
    {
        this.item = item;
        SetUI();
    }

    public void Deinit()
    {
        item = null;

        itemName.text = "";
        icon.sprite = null;
        background.color = Color.white;
        textLevel.text = "";
        textCur.text = "";
        textNext.text = "";
        textRate.text ="";
    }

    public void SetUI()
    {
        itemName.text = item.weaponName;
        icon.sprite = item.sprite;
        textLevel.text = "Lv." + item.level;
        textCur.text = "현재 공격력 : " + item.damage[item.level];
        textNext.text = "다음 공격력 : " + item.damage[item.level + 1];
        textRate.text = "성공확률 : " + item.successRate[item.level];
        
        if(item == null)
        {
            background.color = Color.white;
            return;
        }

        switch(item.weaponTier)
        {
            case ItemSO.WeaponTier.Normal:
                background.color = new Color32(0, 60, 255, 255);

                break;

            case ItemSO.WeaponTier.Epic:
                background.color = new Color32(169, 0, 233, 255);

                break;

            case ItemSO.WeaponTier.Legendary:
                background.color = new Color32(255, 240 ,0, 255);

                break;
        }
    }

    public void Upgrade()
    {
        if(item == null) return;

        if(isMax)
            return;


        int ran = Random.Range(1, 101);
        if(ran <= item.successRate[item.level])
        {
            Success();
        }
        else
        {
            Fail();
        }
    }
    
    

    void Success()
    {
        item.level++;
        draggableUI.levelText.text = "Lv." + item.level;
        // 능력 업데이트 해야지..

        // if(item.level >= item.value.Length)
        // {
        //     // max level에 도달하면
        //     MaxLevel();
        // }
        SetUI();
    }

    void Fail()
    {
        item.level = 0;

        // 강화 실패하면 터진다.
        draggableUI.gameObject.SetActive(false);

        Deinit();
    }
}
