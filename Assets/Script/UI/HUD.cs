using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType {Coin, Time}
    public InfoType type;

    Text myText;

    void Awake()
    {
        myText = GetComponent<Text>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch(type)
        {
            case InfoType.Coin:
                myText.text = GameManager.Inst.Coin.ToString();
                break;
            
            case InfoType.Time:
                float remainTime = (GameManager.Inst.isFight ? GameManager.Inst.maxStageTime : GameManager.Inst.maxPreStageTime) - GameManager.Inst.stageTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
        }
    }
}
