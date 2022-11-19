using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    private GameObject clicked_Object;
    private GameObject player;
    private float distance;
    public float pickup_distance;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        clicked_Object = GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>().clicked;
        if (clicked_Object == gameObject){
            checkClicked();
        }
    }

    // void OnTriggerEnter2D(Collider2D other) {
    //     if (other.CompareTag("Player")) {
    //         Debug.Log("collision!");
    //         Debug.Log(clicked_Object);
    //             for (int i= 0; i < inventory.slots.Length; i++)
    //             {
    //                 if (inventory.isFull[i] == false) {
    //                     //ITEM CAN BE ADDED
    //                     inventory.isFull[i] = true;
    //                     Instantiate(itemButton, inventory.slots[i].transform, false); // false = not world coordinates
    //                     Destroy(gameObject);
    //                     break;
    //                 }
    //             }
    //     }
    // }

    void checkClicked() {
        Debug.Log(clicked_Object.name);
        distance = GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>().Distance();
        print("distance is "+ distance + " from " + clicked_Object);
        if (distance < pickup_distance){
            for (int i= 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false) {
                     //ITEM CAN BE ADDED
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false); // false = not world coordinates
                    Destroy(gameObject);
                    break;
                }
            }
        }
        else{
            GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>().clicked = null;
        }
    }
}

