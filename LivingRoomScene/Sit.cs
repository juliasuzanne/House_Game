using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sit : MonoBehaviour
{
    private SceneSwitch _sceneManager;

    public GameObject clicked_Object;
    private GameObject _dialogGameObject;
    public ClickManager clickManager;
    private Player _player;
    public float timeUntilCloseTable;
    private GameObject _playerObject;
    private Dialog _dialog;
    private GameObject _sitPlayer;
    private bool sitable = true;



    // Start is called before the first frame update
    void Start()
    {
        _sceneManager = GameObject.Find("GameManager").GetComponent<SceneSwitch>();
        _dialogGameObject = GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetChild(0).gameObject;
        _dialog = GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetChild(0).GetComponent<Dialog>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _playerObject = GameObject.FindGameObjectWithTag("Player");

        _sitPlayer = transform.GetChild(0).gameObject;

        // Debug.Log("Get Dialog: " + _dialog);

    }

    // Update is called once per frame
    void Update()
    {
        clicked_Object = GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>().clicked;
        clickManager = GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>();

        //ADD A VARIABLE HERE TO STOP FROM RESPONDING IF INVENTORY IS BEING USED
        if (clicked_Object == gameObject && sitable == true)
        {
            StartCoroutine("Sitting");
        }
        else
        {

        }
    }

    public void NotSitable()
    {
        sitable = false;
    }

    IEnumerator Sitting()
    {
        _playerObject.SetActive(false);
        _sitPlayer.SetActive(true);
        yield return new WaitForSeconds(timeUntilCloseTable);
        _sceneManager.GoToTable();



    }
}

