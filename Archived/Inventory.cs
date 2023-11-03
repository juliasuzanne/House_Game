using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public bool[] isFull; // use to check if there is already an item in each slot
   public GameObject[] slots; // this to place items in the center of each slot, or drop
   public GameObject[] items; // 

   //variable gameObject item
   public void AddItemToInventory()
   {
      foreach (bool full in isFull)
      {
         if (full == true)
         {
            Debug.Log(full + " is TRUE");
         }
         else
         {
            Debug.Log(full + " is FALSE");
         }
      }
   }

}


