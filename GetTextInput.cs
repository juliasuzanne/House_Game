using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GetTextInput : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _input;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_input.text);
    }
    void SaveInput()
    {
        Debug.Log(this.name);
    }
}