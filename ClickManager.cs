using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{

    //The click mananger returns the object that was clicked and the distance between the player and that object.

    private Transform t;
    private Transform player;
    public GameObject clicked;

    // bool dragging = false;
    // GameObject drag_element;

    // Vector3 mouse_position;
    // Vector3 previous_mouse_position;


    void Awake()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                clicked = hit.collider.gameObject;
                //Debug.Log(hit.collider.gameObject.name);
                t = hit.collider.gameObject.transform;
                player = GameObject.FindGameObjectWithTag("Player").transform;
                //print(player.name + " is " + Distance().ToString() + " units from " + hit.collider.gameObject.name);
            }
        }
    }

    public float Distance()
    {
        return Vector3.Distance(t.position, player.position);
    }
}