using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int combineSceneIndex;
    public int behindDoorSceneIndex;

    private UIManager _uiManager;

    void Start()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

    }

    // Start is called before the first frame update
    public void SwitchToDragToCombine()
    {
        _uiManager.SaveGame();
        SceneManager.LoadScene(combineSceneIndex);

    }
    public void GoInDoor()
    {
        _uiManager.SaveGame();
        Debug.Log("Saved Game");
        _uiManager.LoadGame();
        SceneManager.LoadScene(behindDoorSceneIndex);
        _uiManager.LoadGame();
        Debug.Log("Loaded Game");


    }


}
