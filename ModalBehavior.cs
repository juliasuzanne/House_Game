using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalBehavior : MonoBehaviour
{

    [SerializeField]
    private GameObject _modal;
    GameManager _gameManager;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _modal.gameObject.SetActive(false);

    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        _gameManager.PauseGame();
        _modal.gameObject.SetActive(true);
    }

    void OnMouseUp()
    {
    }


    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);

    }
    public void ExitModal()
    {
        _gameManager.ResumeGame();
        _modal.gameObject.SetActive(false);

    }
}
