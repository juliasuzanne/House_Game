using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Image m_Image;
    public Sprite m_Sprite;
    public Inventory inventory;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        //Fetch the Image from the GameObject

    }

    void Update(){
    }

    public void ChangeImage(){
        //Press space to change the Sprite of the Image
            m_Image.sprite = m_Sprite;
            print(inventory.slots[1]);

    }
}
