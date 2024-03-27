using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public int index;
    public string itemName;
    public string description;
    public CountType countType;  
    public ItemType itemType;
    public string imagePath;
    public int itemCount;
    public int maxCount; 
}

public enum CountType
{
    NonCountable, Countable
}
public enum ItemType
{
    Equipment, Consumable
}
