using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;




public class InventoryButton : MonoBehaviour
{

    [SerializeField]
    private string _name;

    [SerializeField]
    private Image _image;

    private Inventory inventory;
    private UIManager _uiManager;

    private bool moving = false;

    private Vector3 mousePosition;

    private float offsetX, offsetY;
    public static bool mouseButtonReleased = true;

    private bool current_so;


    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("The UIManager is NULL");
        }
    }

    void Update()
    {

        if (moving == true)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;
        }

        Debug.Log("Current SO " + current_so);
    }

    void OnMouseDown()
    {
        if (moving == true)
        {
            moving = false;
        }
        else if (moving == false && current_so == true)
        {
            moving = true;
        }
    }




    private void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameobjectName;
        string collisionGameobjectName;

        thisGameobjectName = gameObject.name;
        collisionGameobjectName = collision.gameObject.name;

        // Debug.Log("This: " + thisGameobjectName + "collision with :" + collisionGameobjectName);
    }




    public void UseLeaf()
    {
        current_so = _uiManager.so.leaf;


        if (_name == "leaf" && _uiManager.so.leaf == true)
        {
            moving = true;

        }
        else if (_name == "leaf" && _uiManager.so.leaf == false)
        {

        }

        else
        {
        }


    }

    public void UseRock()
    {

        current_so = _uiManager.so.rock;

        if (_name == "rock" && _uiManager.so.rock == true)
        {
            moving = true;


        }
        else if (_name == "rock" && _uiManager.so.rock == false)
        {

        }
        else
        {
        }


    }

    public void UseBand()
    {
        current_so = _uiManager.so.band;


        if (_name == "band" && _uiManager.so.band == true)
        {
            Debug.Log("Band is Useable");
            moving = true;


        }
        else if (_name == "band" && _uiManager.so.band == false)
        {
            Debug.Log("Band is not Useable");

        }
        else
        {
            Debug.Log("Called but not working");
        }


    }

}

