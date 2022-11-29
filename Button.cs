using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Image m_Image;
    public Sprite m_Sprite;
    public Inventory inventory;
    private GameObject clicked_Object;
    public int slot;
    
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }


    void Update(){
        //  clicked_Object = GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>().clicked;
        //     if (clicked_Object == gameObject){
        //         print("IF1" + clicked_Object);
        //         print("IF2" + gameObject);
        //         ChangeImage();
        //     }       
    }

    public void ChangeImage(){      
        m_Image.sprite = m_Sprite;
        }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("")) {
            
        }
    }

}