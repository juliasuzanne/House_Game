using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePaper : MonoBehaviour
{

    private bool pencil = false;
    private int paperTouchCount = 0;
    private Animator animator;
    private SpriteRenderer sp;

    public Sprite[] sprites;
    private SceneSwitch _sceneManager;

    private bool drawingComplete = false;



    // Start is called before the first frame update
    void Start()
    {

        animator = transform.GetComponent<Animator>();
        sp = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _sceneManager = GameObject.Find("GameManager").GetComponent<SceneSwitch>();


    }

    void OnMouseDown()
    {
        if (pencil == true && drawingComplete == false)
        {
            switch (paperTouchCount)
            {
                case 12:
                    drawingComplete = true;
                    _sceneManager.ExitTable();

                    break;
                case 11:
                    sp.sprite = sprites[10];
                    paperTouchCount = 12;
                    break;
                case 10:
                    sp.sprite = sprites[9];
                    paperTouchCount = 11;
                    break;
                case 9:
                    sp.sprite = sprites[8];
                    paperTouchCount = 10;
                    break;
                case 8:
                    sp.sprite = sprites[7];
                    paperTouchCount = 9;
                    break;
                case 7:
                    sp.sprite = sprites[6];
                    paperTouchCount = 8;
                    break;
                case 6:
                    sp.sprite = sprites[5];
                    paperTouchCount = 7;
                    break;
                case 5:
                    sp.sprite = sprites[4];
                    paperTouchCount = 6;
                    break;

                case 4:
                    sp.sprite = sprites[3];
                    paperTouchCount = 5;
                    break;

                case 3:
                    sp.sprite = sprites[2];
                    paperTouchCount = 4;
                    break;

                case 2:
                    sp.sprite = sprites[1];
                    paperTouchCount = 3;
                    break;

                case 1:
                    sp.sprite = sprites[0];
                    paperTouchCount = 2;
                    break;
                case 0:
                    animator.SetTrigger("rotate");
                    paperTouchCount = 1;
                    break;
            }

        }
        else if (pencil == false && drawingComplete == false)
        {
            animator.SetTrigger("rotate");
            paperTouchCount = 1;
        }

    }



    public void TookPencil()
    {
        pencil = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
