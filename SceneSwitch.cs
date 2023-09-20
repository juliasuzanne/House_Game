using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int combineSceneIndex;
    public int behindDoorSceneIndex;

    // Start is called before the first frame update
    public void SwitchToDragToCombine()
    {
        SceneManager.LoadScene(combineSceneIndex);
    }
    public void GoInDoor()
    {
        SceneManager.LoadScene(behindDoorSceneIndex);
    }


}
