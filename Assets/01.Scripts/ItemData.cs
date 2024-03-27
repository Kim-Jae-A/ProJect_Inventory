using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemData : MonoBehaviour, IPointerDownHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    // ������ ����
    public Item item_Info;

    // ������ ���� ����
    public bool inItem;

    #region ������ �̵��� ���� ������Ʈ
    public Transform moveSlot;
    private Transform slot;
    private Vector2 _beginPoint;
    private Vector2 _moveBegin;
    #region ���� ����
    private ItemSlotMove slotMove;
    public Item endSlotitem;
    #endregion
    #endregion

    [Header("������ ǥ���� ��׶���")]
    [SerializeField] private Image item_Image;

    [Header("������ ����")]
    [SerializeField] private TextMeshProUGUI item_Count_Text;



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
            if (item_Info.countType == CountType.Countable)
            {
                item_Count_Text.text = $"{item_Info.itemCount}";
                item_Count_Text.gameObject.SetActive(true);
            }
            else
            {
                item_Count_Text.gameObject.SetActive(false);
            }
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
        item_Count_Text.gameObject.SetActive(false);
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
