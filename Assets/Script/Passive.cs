using System.IO.Enumeration;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Passive : MonoBehaviour
{
    public PassiveData data;
    public int level;
    
    [SerializeField] private Image icon;
    [SerializeField] private Text textLevel;
    [SerializeField] private Text textName;
    [SerializeField] private Text textCur;
    [SerializeField] private Text textNext;
    [SerializeField] private Text textCost;
    [SerializeField] private Text textRate;

    void OnEnable()
    {
        icon.sprite = data.passiveIcon;
        SetText();
    }
    void SetText()
    {

        textLevel.text = "Lv." + (level);
        textName.text = "기본 " + data.passiveName + " 강화";
        textCur.text = "현재   " + (data.baseValue + (level == 0 ? 0 : data.value[level - 1])).ToString();
        textNext.text = "다음   " + (data.baseValue + data.value[level]).ToString();
        textCost.text = "비용 " + data.cost[level].ToString();
        textRate.text = "성공확률 : " + data.successRate[level].ToString() + "%";
    }


    public void Upgrade()
    {
        if(!CoinCheck())
            return;

        GameManager.Inst.Coin -= data.cost[level];
        
        int ran = Random.Range(1, 101);
        if(ran <= data.successRate[level])
        {
            Success();
        }
        else
        {
            Fail();
        }

        SetText();
    }
    
    bool CoinCheck()
    {
        if(GameManager.Inst.Coin < data.cost[level])
        {
            return false;
        }    
        return true;
    }
    

    void Success()
    {
        level++;
        if(level == data.value.Length)
        {
            // max level에 도달하면
            MaxLevel();
        }
    }

    void Fail()
    {
        level = 0;
    }

    void MaxLevel()
    {

    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
