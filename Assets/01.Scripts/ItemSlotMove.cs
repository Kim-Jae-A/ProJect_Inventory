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
    
    public ItemData startSlot;
    public ItemData endSlot;

    public Item item;
    public Item swapitem;

    private void OnEnable()
    {
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = Resources.Load<Sprite>(item.imagePath);
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

        /*if(item.countType == CountType.Countable && swapitem.countType == CountType.Countable)
        {

        }*/

        endSlot.ItemDrawing(swapitem);
        startSlot.ItemDrawing(item);
    }
}
