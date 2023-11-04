using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPickup : MonoBehaviour
{
    private Vector2 mousePosition;

    private float offsetX, offsetY;
    public static bool mouseButtonReleased = false;

    private Vector3 startingPos;

    void Start()
    {
        startingPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (mouseButtonReleased == true)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 99f;
            transform.position = mousePosition;

        }
        if (Input.GetMouseButtonDown(0))
        {
            StopMoving();
        }


    }
    public void DragMouse()
    {
        mouseButtonReleased = true;
    }

    void OnMouseDown()
    {
        mouseButtonReleased = false;
    }

    private void StopMoving()
    {
        transform.position = startingPos;
        mouseButtonReleased = false;
    }
}
