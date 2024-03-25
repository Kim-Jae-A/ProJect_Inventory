using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemData : MonoBehaviour
{
    // ������ ����
    public Item item_Info;

    // ������ ���� ����
    public bool inItem;

    [Header("������ ǥ���� ��׶���")]
    [SerializeField] private Image item_Image;

    [Header("������ ����")]
    [SerializeField] private TextMeshProUGUI item_Count_Text;

    public void ItemDrawing(Item item)
    {
        item_Image.gameObject.SetActive(true);
        item_Info = item;
        item_Image.sprite = item.itemimage;
    }

}
