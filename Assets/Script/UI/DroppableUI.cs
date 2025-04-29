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
        Item item = draggedObject.GetComponent<DraggableUI>().item;
        SlotType previousSlotType = draggedObject.GetComponent<DraggableUI>().previousSlotType;

        //eventData.pointerDrag.transform.SetParent(transform);
        eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        
        

        // 무기 장착
        if (slotType == SlotType.Selected && previousSlotType == SlotType.Inventory)
        {
            // weapon 초기화
            weapon.Init(item);

            // selected slot 초기화
            slotItem.SetActive(true);
            slotItem.GetComponent<DraggableUI>().Init(item);
            
            
            // inventory slot 초기화
            //draggedObject.SetActive(false);
            draggedObject.GetComponent<DraggableUI>().isActive = false;
        }
        // 무기 장착 해제 
        else if(slotType == SlotType.Inventory && previousSlotType == SlotType.Selected)
        {
            // 장착 해제 실행
            draggedObject.GetComponent<DraggableUI>().previousParent.GetComponent<DroppableUI>().weapon.Unequip();
            
            // selected slot 초기화
            //draggedObject.SetActive(false);
            draggedObject.GetComponent<DraggableUI>().isActive = false;

            // inventory slot 초기화
            slotItem.SetActive(true);
            slotItem.GetComponent<DraggableUI>().Init(item);
        }
    }
}
