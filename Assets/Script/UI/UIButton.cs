using UnityEngine;

public class UIButton : MonoBehaviour
{
    public enum ButtonType {UpgradeTab, EquipTab}
    
    public ButtonType buttonType;
    public GameObject uiTab;
    bool isOpen;


    public void OnClick()
    {
        // 열려 있으면 ?
        if(isOpen)
        {
            isOpen = false;
            uiTab.SetActive(false);
        }
        else{
            isOpen = true;
            uiTab.SetActive(true);
        }
    }
}
