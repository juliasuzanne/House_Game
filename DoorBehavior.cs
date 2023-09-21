using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    private bool openable = false;
    private SceneSwitch _sceneManager;
    private UIManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        _sceneManager = GameObject.Find("GameManager").GetComponent<SceneSwitch>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //add menu here to confirm leaving the room? or animation with the door swinging open, on hover message "go to ..."
        if (openable == true)
        {
            _sceneManager.GoInDoor();
        }
        else
        {

        }
    }

    void OnMouseUp()
    {
        Debug.Log("Released mouse from door");
    }


    public void OpenDoor()
    {
        openable = true;
        _uiManager.so.stairDoorOpen = true;
    }
}
