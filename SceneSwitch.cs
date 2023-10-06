using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int combineSceneIndex;
    public int behindDoorSceneIndex;
    public int oldLadyLivingRoomSceneIndex;

    public int stairsSceneIndex;

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

    public void StairScene()
    {
        _uiManager.SaveGame();
        SceneManager.LoadScene(2);

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

    public void ExitNightmare()
    {

        // _uiManager.SaveGame();
        // Debug.Log("Saved Game");
        // _uiManager.LoadGame();
        SceneManager.LoadScene(oldLadyLivingRoomSceneIndex);
        //     _uiManager.LoadGame();
        //     Debug.Log("Loaded Game");
        // 
    }

    public void ExitTable()
    {
        _uiManager.SaveGame();
        SceneManager.LoadScene(6);

    }

    public void GoToTable()
    {
        _uiManager.SaveGame();
        SceneManager.LoadScene(5);
    }


}
