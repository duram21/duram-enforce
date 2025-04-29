using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform canvas;
    public Transform previousParent;
    public RectTransform rect;
    public CanvasGroup canvasGroup;
    public Image image;
    public Item item;
    public DroppableUI.SlotType previousSlotType;

    public bool isActive;


    void Awake()
    {
        canvas =  FindFirstObjectByType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        image = GetComponent<Image>();

        Init(item);
    }

    public void Init(Item item)
    {
        this.item = item;
        this.image.sprite = item.sprite;
        isActive=true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(" 드래그 시ㅏㅈㄱ");
        previousParent = transform.parent;
        previousSlotType = previousParent.GetComponent<DroppableUI>().slotType;
        transform.SetParent(canvas);
        transform.SetAsLastSibling();

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        isActive=true;
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

        if(!isActive)
        {
            gameObject.SetActive(false);
        }
    }
}
