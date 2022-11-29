using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int sceneIndex;
    // Start is called before the first frame update
    public void SwitchToDragToCombine(){
        SceneManager.LoadScene(sceneIndex);
    }
}
