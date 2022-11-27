using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   public ItemType itemType;
    public int amount;
    
    public enum ItemType {
        Leaf,
        Band,
        Rock,
        RockWBand,
        String
    }

}
