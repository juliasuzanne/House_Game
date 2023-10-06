using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GetTextInput : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _input;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();


    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SaveInput()
    {
        _uiManager.so.playerName = _input.text;

    }
}