using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkOnEnter : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private GameObject _Broom;
    [SerializeField]
    private GameObject _invButton;

    [SerializeField]
    private Text _text;
    [SerializeField]
    private SceneSwitch _sceneManager;
    private bool finishConversation = false;

    [SerializeField]

    private string[] strings;
    private int count = 0;

    void Start()
    {
        _sceneManager = GameObject.Find("GameManager").GetComponent<SceneSwitch>();
        _text.enabled = true;


    }
    void OnMouseDown()
    {
        if (count < strings.Length)
        {
            count = count + 1;
            _text.text = strings[count];
            _text.enabled = true;
            if (count == 4)
            {
                _panel.SetActive(true);

            }
            else if (count == 6)
            {
                _invButton.SetActive(true);
            }

            else if (count == 8)
            {
                _Broom.SetActive(false);
            }




        }


        else
        {
            _text.enabled = false;

        }

    }


}
