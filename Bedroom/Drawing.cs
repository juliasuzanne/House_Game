using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{

    // private bool pencil = false;
    private int paperTouchCount = 0;
    private SpriteRenderer sp;

    public Sprite[] sprites;
    private SceneSwitch _sceneManager;

    private bool drawingComplete = false;



    // Start is called before the first frame update
    void Start()
    {

        sp = transform.GetComponent<SpriteRenderer>();
        _sceneManager = GameObject.Find("GameManager").GetComponent<SceneSwitch>();
        Debug.Log(sprites.Length);


    }

    void OnMouseDown()
    {
        if (drawingComplete == false)
        {
            // for (int i = 0; i < sprites.Length; i++)
            // {
            //     // Code to be repeated.
            // }

        }


        else if (drawingComplete == true)
        {

        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
