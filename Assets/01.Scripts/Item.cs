using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemimage;
    public int itemCount;
}

public enum ItemType
{

}
