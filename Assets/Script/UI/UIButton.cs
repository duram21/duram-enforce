using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEditor.Rendering;
using UnityEngine;

[System.Serializable]
public class UITabRow
{
    public List<GameObject> uiArray;
}

public class UIButton : MonoBehaviour
{
    public enum ButtonType {UpgradeTab, EquipTab, Ready}
    
    public ButtonType buttonType;
    public List<UITabRow> uiTab;
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
                int openIdx = -1;
                for(int i = 0 ; i < uiTab.Count; i++){
                    if(uiTab[i].uiArray[0].activeSelf) openIdx = i;
                    for (int j = 0; j < uiTab[i].uiArray.Count; j++)
                    {
                        uiTab[i].uiArray[j].SetActive(false);
                    }
                }
                Debug.Log(openIdx);
                if(openIdx != index)
                {
                    for (int j = 0; j < uiTab[index].uiArray.Count; j++)
                    {
                        uiTab[index].uiArray[j].SetActive(true);
                    }
                }

                break;
        }
    }
}
