using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public int index;
    public CountType countType;
    public string itemName;
    public Sprite itemimage;
    public int itemCount;
    public int maxCount;
    
}

public enum CountType
{
    NonCountable, Countable
}
