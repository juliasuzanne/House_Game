using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private GameObject clicked_Object;
    private Dialog _dialog;

    // Start is called before the first frame update
    void Start()
    {
        _dialog = GameObject.FindGameObjectWithTag("Player").gameObject.transform.GetChild(0).GetComponent<Dialog>();

        Debug.Log("Get Dialog: " + _dialog);

        //  clicked_Object = GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>().clicked;
    }

    // Update is called once per frame
    void Update()
    {
        clicked_Object = GameObject.FindGameObjectWithTag("ClickManager").GetComponent<ClickManager>().clicked;

        if (clicked_Object == gameObject)
        {
            _dialog.StartTalking();
        }
    }


}
