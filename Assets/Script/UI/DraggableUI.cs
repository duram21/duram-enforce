using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Transform canvas;
    public Transform previousParent;
    public RectTransform rect;
    public CanvasGroup canvasGroup;
    public Image image;
    public Item item;
    public DroppableUI.SlotType previousSlotType;
    public ItemInfoUI itemInfoUI;
    public DroppableUI parentSlot;
    public Image background;
    public Text levelText;

    public bool isActive = false;


    public void Init(Item item)
    {

        isActive=true;
        this.item = item;
        if(item != null){
            this.image.sprite = item.sprite;
            levelText.text = "Lv." + item.level;        
        }
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

    public void Deinit()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;
        previousSlotType = previousParent.GetComponent<DroppableUI>().slotType;
        transform.SetParent(canvas);
        transform.SetAsLastSibling();

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        isActive=true;
        GameManager.Inst.isDrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("여기 들어온거 아니냐 ? 왜 안되냐 ");
        transform.SetParent(previousParent);
        rect.position = previousParent.GetComponent<RectTransform>().position;

        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        Debug.Log(isActive);
        if(!isActive)
        {
            gameObject.SetActive(false);
        }
        GameManager.Inst.isDrag =false;
        itemInfoUI.Deinit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!GameManager.Inst.isDrag)
            itemInfoUI.Init(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!GameManager.Inst.isDrag)
            itemInfoUI.Deinit();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("마우스로 클릭됨!");
        EnhanceManager.Instance.draggableUI = this;
        EnhanceManager.Instance.Init(item);
    }


}
