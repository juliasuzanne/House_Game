using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    private bool openable = false;
    private SceneSwitch _sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        _sceneManager = GameObject.Find("GameManager").GetComponent<SceneSwitch>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
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
    }
}
