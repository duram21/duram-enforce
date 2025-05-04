using UnityEngine;

public class UIButton : MonoBehaviour
{
    public enum ButtonType {UpgradeTab, EquipTab, Ready}
    
    public ButtonType buttonType;
    public GameObject[] uiTab;
    bool isOpen;


    public void OnClick(int index)
    {
        switch(buttonType)
        {
            case ButtonType.Ready:
                if(GameManager.Inst.isFight) break;
                GameManager.Inst.StartStage();

                break;
            
            default :
                for (int i = 0; i < uiTab.Length; i++)
                {
                    uiTab[i].SetActive(i == index);
                }

                break;
        }
    }
}
