using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    private Inventory inventory;
    public GameObject rock;
    public GameObject band;
    public GameObject rockBand;
    public GameObject slot;
    // Start is called before the first frame update

      void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }


     public void CombineItem(){
        for (int i= 0; i < inventory.slots.Length; i++)
            {
                if (inventory.items[i] == rock){
                    foreach (Transform child in inventory.slots[i].transform){
                    GameObject.Destroy(child.gameObject);
                }
                  for (int s= 0; s < inventory.items.Length; s++){
                    if (inventory.items[s] = gameObject)
                    Destroy(gameObject);
                    inventory.isFull[s] = false;
                    inventory.items[s] = null;
                  }
                    print(inventory.slots[i].transform);
                    Instantiate(rockBand, inventory.slots[i].transform, false); // false = not world coordinates
                    inventory.items[i] = null;
                    inventory.items[i] = rockBand;
                    inventory.isFull[i] = true;
                    break;
                }
            }
    }
}
