using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private Inventory inventory;
    public int score;
    public GameObject image;
    private GameObject added_image;
    public int target_slot;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

    }

    void Update() {
        Instantiate(added_image, inventory.slots[target_slot].transform, false);
    }

    public void ChangeImage(){
        added_image = image;
    }
}