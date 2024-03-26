using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemData : MonoBehaviour, IPointerDownHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    // 아이템 정보
    public Item item_Info;

    // 아이템 존재 유무
    public bool inItem;

    #region 아이템 이동을 위한 오브젝트
    public Transform moveSlot;

    private Transform slot;
    private Vector2 _beginPoint;
    private Vector2 _moveBegin;
    #endregion

    [Header("아이템 표시할 백그라운드")]
    [SerializeField] private Image item_Image;

    [Header("아이템 갯수")]
    [SerializeField] private TextMeshProUGUI item_Count_Text;

    #region 슬롯 변경
    private ItemSlotMove slotMove;
    public Item endSlotitem;
    #endregion

    private void Awake()
    {
        slot = GetComponent<Transform>();
        slotMove = moveSlot.gameObject.GetComponent<ItemSlotMove>();
    }

    public void ItemDrawing(Item item = null)
    {
        if (item != null)
        {
            inItem = true;       
            item_Info = item;
            item_Image.sprite = item.itemimage; 
            item_Image.gameObject.SetActive(true);
        }
        else
        {
            item_Info = null;
            item_Image.sprite = null;
            inItem = false;
            ItemUnDrawing();
        }
    }
    public void ItemUnDrawing()
    {
        item_Image.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _beginPoint = slot.position;
        _moveBegin = eventData.position;      
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (inItem)
        {
            slotMove.item = item_Info;
            slotMove.startSlot = GetComponent<ItemData>();
            moveSlot.gameObject.SetActive(true);
            ItemUnDrawing();
            moveSlot.position = _beginPoint + (eventData.position - _moveBegin);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        slotMove.SwapItemSlot(GetComponent<ItemData>());
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        moveSlot.gameObject.SetActive(false);
        ItemDrawing(item_Info);
    }
}
