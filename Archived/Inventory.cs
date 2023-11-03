using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public bool[] isFull; // use to check if there is already an item in each slot
   public GameObject[] slots; // this to place items in the center of each slot, or drop
   public GameObject[] items; // 
   private int count = 0;
   //variable gameObject item
   public void AddItemToInventory(GameObject prefab)
   {
      count = 0;
      foreach (bool full in isFull)
      {
         if (full == false)
         {
            Debug.Log(full + " is FALSE");
            items[count] = prefab;
            isFull[count] = true;
            Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity, slots[count].transform);
            break;
         }
         else
         {
            Debug.Log(full + " is TRUE");
         }
         count = count + 1;
      }
   }

}


