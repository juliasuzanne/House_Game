using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : InventoryButton
{

    protected GameObject door;
    protected DoorBehavior doorBehavior;

    public void Awake()
    {
        door = GameObject.Find("DoorOpener");
        doorBehavior = door.GetComponent<DoorBehavior>();
        door.SetActive(false);

    }

    public override void Init()
    {
        base.Init();


    }
    public override void OnMousePressed()
    {
        Debug.Log("Mouse Down");
        if (moving == true)
        {

            if (collisionGameobjectName == "Keyhole")
            {
                dialogue.SetActive(true);
                StartCoroutine("Keyhole");

            }
            else if (collided == true)
            {
                dialogue.SetActive(true);
                StartCoroutine("OtherCollision");


            }
            else
            {
                transform.position = startingPoint;
                moving = false;
                can_pickup = false;
                StartCoroutine("CanPickup");
            }

        }
    }

    IEnumerator Keyhole()
    {
        can_pickup = true;
        door.SetActive(true);
        Debug.Log("Door is open");
        doorBehavior.OpenDoor();
        dialogue.SetActive(true);
        player_text.text = "The door is open!";
        _uiManager.MakeInventoryUIShadow(2);
        yield return new WaitForSeconds(1f);
        dialogue.SetActive(false);

    }
}
