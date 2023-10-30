using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    private SceneSwitch _sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        _sceneManager = GameObject.Find("GameManager").GetComponent<SceneSwitch>();

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _sceneManager.GoToCave();
        }
    }
}
