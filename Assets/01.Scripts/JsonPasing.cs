using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonPasing : MonoBehaviour
{
    
}

[System.Serializable]
public class Items
{
    public int index;
    public string itemName;
    public string description;
    public string countType;
    public string itemType;
    public string imagePath;
    public int itemCount;
    public int maxCount;
}

[System.Serializable]
public class ItemsData
{
    public Items[] Items;
}

