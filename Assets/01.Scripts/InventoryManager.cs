using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    ItemData[] itemDatas;

    public Item[] items_info;
    public TextAsset jsonFile;

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
            if (itemDatas[i].item_Info.countType == CountType.Countable && item.itemName == itemDatas[i].item_Info.itemName)
            {
                if(itemDatas[i].item_Info.itemCount + item.itemCount <= itemDatas[i].item_Info.maxCount)
                {
                    itemDatas[i].item_Info.itemCount += item.itemCount;
                    itemDatas[i].ItemDrawing(item);
                    break;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //int random = Random.Range(0, items_info.Length);
            jsonFile = Resources.Load<TextAsset>("Items");
            string jsonString = jsonFile.text;
            ItemsData itemsData = JsonUtility.FromJson<ItemsData>(jsonString);
            foreach (Items items in itemsData.Items)
            {
                Debug.Log("Item Name: " + items.itemName);
                Debug.Log("Description: " + items.description);
                Debug.Log("Count Type: " + items.countType);
                Debug.Log("Item Type: " + items.itemType);
                Debug.Log("Image Path: " + items.imagePath);
                Debug.Log("Item Count: " + items.itemCount);
                Debug.Log("Max Count: " + items.maxCount);
                Debug.Log("----------------------------------");
            }
            //EatItem(items_info[random]);
        }
    }
}
