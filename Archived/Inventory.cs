using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
   public bool[] isFull; // use to check if there is already an item in each slot
   public GameObject[] slots; // this to place items in the center of each slot, or drop
   public GameObject[] items; // 
   private int count = 0;
   private Text _playerText;
   private Transform _player;
   private GameObject _dialog;
   private Player _playerScript;


   void Start()
   {
      _player = GameObject.Find("Player").transform;
      _playerScript = GameObject.Find("Player").transform.GetComponent<Player>();
      _dialog = _player.GetChild(0).GetChild(0).gameObject;
      _playerText = GameObject.Find("Player").transform.GetChild(0).GetChild(0).gameObject.transform.GetComponent<Text>();
   }

   public void AddItemToInventory(GameObject prefab)
   {

      count = 0;
      foreach (bool full in isFull)
      {
         if (full == false)
         {
            Vector3 slotPos = new Vector3(slots[count].transform.position.x, slots[count].transform.position.y, 79f);
            Debug.Log(count + " is FALSE");
            items[count] = prefab;
            isFull[count] = true;
            Instantiate(prefab, slotPos, Quaternion.identity, slots[count].transform);
            break;
         }
         else
         {
            if (count == slots.Length - 1)
            {
               _dialog.SetActive(true);
               _playerText.text = "I guess I need to get rid of something";
               StartCoroutine("LetPlayerTalk");
               break;
            }
            Debug.Log(count + " is TRUE");
         }
         count = count + 1;
      }
   }

   IEnumerator LetPlayerTalk()
   {
      yield return new WaitForSeconds(3f);
      _dialog.SetActive(false);

   }

}


