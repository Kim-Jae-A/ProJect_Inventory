using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemData : MonoBehaviour
{
    // 아이템 정보
    public Item item_Info;

    // 아이템 존재 유무
    public bool inItem;

    [Header("아이템 표시할 백그라운드")]
    [SerializeField] private Image item_Image;

    [Header("아이템 갯수")]
    [SerializeField] private TextMeshProUGUI item_Count_Text;

    public void ItemDrawing(Item item)
    {
        item_Image.gameObject.SetActive(true);
        item_Info = item;
        item_Image.sprite = item.itemimage;
    }

}
