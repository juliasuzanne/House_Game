using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeActiveOnClick : MonoBehaviour
{

    [SerializeField]
    private GameObject _panel;
    // Start is called before the first frame update


    void OnMouseDown()
    {
        Debug.Log("Button CLICKED");
        if (_panel.activeSelf == true)
        {
            _panel.SetActive(false);
        }
        else
        {
            _panel.SetActive(true);
            transform.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
