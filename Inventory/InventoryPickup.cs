using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPickup : MonoBehaviour
{
    private Vector2 mousePosition;

    private float offsetX, offsetY;
    public static bool mouseButtonReleased = false;
    private Transform _item;
    private Vector3 startingPos;
    private Inventory _inventory;

    void Start()
    {
        startingPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();
    }

    void Update()
    {
        if (mouseButtonReleased == true)
        {

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 99f;
            _item.position = mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                StopMoving();
            }

        }



    }
    public void DragMouse()
    {
        _item = this.transform;
        mouseButtonReleased = true;
    }

    private void StopMoving()
    {
        _item = null;
        transform.position = startingPos;
        mouseButtonReleased = false;
        Destroy(this.gameObject);
    }
}
