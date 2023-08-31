using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    private UIManager _uiManager;

    [SerializeField]
    private int pickup_id;
    private GameObject clicked_Object;
    private GameObject player;
    private float distance;
    // public GameObject _uiManager;
    public float pickup_distance;
    public SaveObject so;



    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player");
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("The UIManager is NULL");
        }

    }

    void Update()
    {
        clicked_Object = GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>().clicked; //constantly checking if this item matches the clicked item, this seems inefficient
        if (clicked_Object == gameObject)
        {
            checkClicked();
        }
    }


    void checkClicked()
    {
        Debug.Log(clicked_Object.name);
        distance = GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>().Distance();
        print("distance is " + distance + " from " + clicked_Object);
        if (distance < pickup_distance)
        {
            _uiManager.AddToInventory(pickup_id);
            this.gameObject.SetActive(false);

        }
        else
        {
            GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>().clicked = null;
        }
    }

}

