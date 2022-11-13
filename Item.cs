using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType{
        Flower,
        Gem,
        Bones,
        Rocks
        }
    public ItemType itemType;
    public int amount;
}
