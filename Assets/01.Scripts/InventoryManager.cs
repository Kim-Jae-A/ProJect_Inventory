using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    ItemData[] itemDatas;

    public Item[] items_info;
    

    private void Awake()
    {
        itemDatas = GetComponentsInChildren<ItemData>();
    }

    public void EatItem(Item item)
    {
        for (int i = 0; i < itemDatas.Length; i++)
        {
            if (!itemDatas[i].inItem)
            {
                itemDatas[i].inItem = true;
                itemDatas[i].ItemDrawing(item);
                break;
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        { 
            int random = Random.Range(0, items_info.Length);
            EatItem(items_info[random]);
        }
    }
}
