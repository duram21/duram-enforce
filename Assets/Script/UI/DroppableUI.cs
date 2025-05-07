using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DroppableUI : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    public enum SlotType {Selected, Inventory}
    public Image image;
    public RectTransform rect;
    public SlotType slotType;
    public Weapon weapon;
    public GameObject slotItem;


    void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.gray;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(!eventData.pointerDrag)
            return;

        GameObject draggedObject = eventData.pointerDrag;
        DraggableUI draggedSlot = draggedObject.GetComponent<DraggableUI>();
        Item item = draggedSlot.item;
        SlotType previousSlotType = draggedSlot.previousSlotType;

        eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        
        // 시작지점은 무조건 오브젝트 있음.. 일단 두 슬롯의 정보를 교환
        Item itemFrom = item;
        Item itemTo = slotItem.GetComponent<DraggableUI>().item;
        draggedSlot.Init(itemTo);
        slotItem.GetComponent<DraggableUI>().Init(itemFrom);
        if(slotType == SlotType.Selected)
        {
            weapon.Init(item);
        }


        // 기존거 해제..
        if(previousSlotType == SlotType.Selected)
        {
            draggedSlot.parentSlot.weapon.Unequip();
        }
        draggedSlot.isActive = false;

        // 기존의 To(옮긴 위치) Slot이 활성화 되어 있으면 ?
        if(slotItem.activeSelf) 
        { 
            draggedSlot.isActive = true;
            if(previousSlotType == SlotType.Selected)
            {
                draggedSlot.parentSlot.weapon.Init(itemTo);
            }
        }
        slotItem.SetActive(true);

        
        
    }
}
