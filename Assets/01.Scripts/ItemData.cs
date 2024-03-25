using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemData : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    // ���� ���� �ѹ�
    [HideInInspector] public int slotnum = 0;

    // ������ ����
    public Item item_Info;

    // ������ ���� ����
    public bool inItem;

    public Transform moveSlot;

    private Transform slot;
    private Vector2 _beginPoint;
    private Vector2 _moveBegin;

    [Header("������ ǥ���� ��׶���")]
    [SerializeField] private Image item_Image;

    [Header("������ ����")]
    [SerializeField] private TextMeshProUGUI item_Count_Text;

    private void Awake()
    {
        slot = GetComponent<Transform>();
    }

    public void ItemDrawing(Item item = null)
    {
        if (item != null)
        {
            item_Image.gameObject.SetActive(true);
            item_Info = item;
            item_Image.sprite = item.itemimage;
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
        moveSlot.gameObject.GetComponent<ItemSlotMove>().item = item_Info;
        moveSlot.gameObject.SetActive(true);
        ItemUnDrawing();
        moveSlot.position = _beginPoint + (eventData.position - _moveBegin);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        moveSlot.gameObject.SetActive(false);
        item_Image.gameObject.SetActive(true);
        //eventData.
    }
}
