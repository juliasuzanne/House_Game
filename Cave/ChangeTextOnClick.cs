using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextOnClick : MonoBehaviour
{

  // private bool pencil = false;
  private int count = 0;
  private Text _text;

  public string[] strings;
  private SceneSwitch _sceneManager;

  private bool finishConversation = false;



  // Start is called before the first frame update
  void Start()
  {

    _text = transform.gameObject.GetComponent<Text>();
    _sceneManager = GameObject.Find("GameManager").GetComponent<SceneSwitch>();
    Debug.Log(strings.Length);
    _text.enabled = true;


  }

  void OnMouseDown()
  {
    if (count < strings.Length)
    {
      count = count + 1;
      _text.text = strings[count];
      _text.enabled = true;

    }


    else if (count == strings.Length)
    {
      _text.enabled = false;
    }

  }


  // Update is called once per frame
  void Update()
  {

  }
}
