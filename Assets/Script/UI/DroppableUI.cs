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


    void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.yellow;
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
        Item item = draggedObject.GetComponent<DraggableUI>().item;
        SlotType previousSlotType = draggedObject.GetComponent<DraggableUI>().previousSlotType;

        eventData.pointerDrag.transform.SetParent(transform);
        eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        
        Debug.Log(previousSlotType);


        // 무기 장착
        if (slotType == SlotType.Selected && previousSlotType == SlotType.Inventory)
        {
            weapon.Init(item);
        }
        // 무기 장착 해제 
        else if(slotType == SlotType.Inventory && previousSlotType == SlotType.Selected)
        {
            Debug.Log("장착 해제");
            Debug.Log(weapon == null);
            draggedObject.GetComponent<DraggableUI>().previousParent.GetComponent<DroppableUI>().weapon.Unequip();
        }
    }
}
