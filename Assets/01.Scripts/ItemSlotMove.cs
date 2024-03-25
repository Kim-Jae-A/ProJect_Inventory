using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotMove : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI itemCount;
    public Item item;

    private void OnEnable()
    {
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = item.itemimage;
    }
}
