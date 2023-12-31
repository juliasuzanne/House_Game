using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject clicked_Object;
    private GameObject _dialogGameObject;

    public ClickManager clickManager;
    private Player _player;

    [SerializeField]
    private DialogCave _dialog;



    // Start is called before the first frame update
    void Start()
    {
        _dialogGameObject = GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetChild(0).gameObject;
        _dialog = GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetChild(0).GetComponent<DialogCave>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        // Debug.Log("Get Dialog: " + _dialog);

    }

    // Update is called once per frame
    void Update()
    {
        clicked_Object = GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>().clicked;
        clickManager = GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>();

        //ADD A VARIABLE HERE TO STOP FROM RESPONDING IF INVENTORY IS BEING USED
        if (clicked_Object == gameObject)
        {
            clickManager.MakeNull();
            _player.MoveableFalse();
            Debug.Log("Moveable false is called in NPC script");
            _dialog.StartTalking();

        }
        else
        {

        }
    }


}