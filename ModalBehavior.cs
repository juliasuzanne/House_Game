using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalBehavior : MonoBehaviour
{

    [SerializeField]
    private GameObject _modal;
    GameManager _gameManager;
    private Player _player;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    // Start is called before the first frame update
    void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _modal.gameObject.SetActive(false);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();


    }
    void Update()
    {
        hotSpot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
        _player.MoveableFalse();
        Debug.Log("Mouse Down on " + _modal.gameObject.name);
    }

    void OnMouseUp()
    {
    }


    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);

    }
    public void ExitDeskModal()
    {
        _modal.gameObject.SetActive(false);
        _gameManager.ResumeGame();
        _player.MoveableTrue();
    }
}
