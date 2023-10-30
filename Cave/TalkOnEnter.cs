using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkOnEnter : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;

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
        if (count <= strings.Length)
        {
            count = count + 1;
            _text.text = strings[count];
            _text.enabled = true;
            if (count == 3)
            {
                _panel.SetActive(true);

            }
            else
            {
                _panel.SetActive(false);
            }

        }


        else if (count > strings.Length)
        {
            _text.enabled = false;
            count = 5;
        }

    }


}
