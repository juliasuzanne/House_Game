using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InventoryButton : MonoBehaviour
{

    [SerializeField]
    private string _name;

    [SerializeField]
    private Image _image;

    private Inventory inventory;
    private UIManager _uiManager;

    private bool moving = false;

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
            Debug.Log(transform.position);
        }

    }


    public void UseLeaf()
    {

        if (_name == "leaf" && _uiManager.so.leaf == true)
        {
            Debug.Log("Leaf is Useable");
            moving = true;
        }
        else if (_name == "leaf" && _uiManager.so.leaf == false)
        {
            Debug.Log("Leaf is not Useable");
        }
        else
        {
            Debug.Log("Called but not working");
        }


    }

    public void UseRock()
    {

        if (_name == "rock" && _uiManager.so.rock == true)
        {
            Debug.Log("Rock is Useable");
            moving = true;

        }
        else if (_name == "rock" && _uiManager.so.rock == false)
        {
            Debug.Log("Rock is not Useable");
        }
        else
        {
            Debug.Log("Called but not working");
        }


    }

    public void UseBand()
    {

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

