using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToCombine : MonoBehaviour
{
    private Vector2 mousePosition;

    private float offsetX, offsetY;
    public static bool mouseButtonReleased;


    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x - offsetX, mousePosition.y - offsetY, transform.position.z);

    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;

    }

    // private void OnTriggerStay2D(Collider2D collision)
    // {
    //     string thisGameobjectName;
    //     string collisionGameobjectName;

    //     thisGameobjectName = gameObject.name.Substring(0, name.IndexOf("_"));
    //     collisionGameobjectName = collision.gameObject.name.Substring(0, name.IndexOf("_"));

    //     if (mouseButtonReleased && thisGameobjectName == "string" && thisGameobjectName == collisionGameobjectName)
    //     {
    //         Instantiate(Resources.Load("yarn_drag"), transform.position, Quaternion.identity);
    //         mouseButtonReleased = false;
    //         Destroy(collision.gameObject);
    //         Destroy(gameObject);
    //     }
    //     else if (mouseButtonReleased && thisGameobjectName == "leaf" && collisionGameobjectName == "yarn")
    //     {
    //         Instantiate(Resources.Load("string_drag"), transform.position, Quaternion.identity);
    //         mouseButtonReleased = false;
    //         Destroy(collision.gameObject);
    //         Destroy(gameObject);
    //     }
    // }
}
