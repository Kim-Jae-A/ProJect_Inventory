using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotMove : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI itemCount;
    public Item item;
    public ItemData startSlot;
    public ItemData endSlot;
    Item swapitem;

    private void OnEnable()
    {
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = item.itemimage;
    }

    public void SwapItemSlot(ItemData _endSlot)
    {
        if (_endSlot == null)
        {
            return;
        }
        endSlot = _endSlot;
        swapitem = item;
        item = endSlot.item_Info;
        endSlot.ItemDrawing(swapitem);
        startSlot.ItemDrawing(item);
    }
}
