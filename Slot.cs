using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image m_Image;
    public Sprite m_Sprite;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CombineItem(){
    }

    public void DropItem(){
        foreach (Transform child in transform){
            GameObject.Destroy(child.gameObject);
            inventory.isFull[0] = false;
        }
    }
}
