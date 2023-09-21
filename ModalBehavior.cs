using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalBehavior : MonoBehaviour
{

    [SerializeField]
    private GameObject _modal;
    GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _modal.gameObject.SetActive(false);

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

    public void ExitModal()
    {
        _gameManager.ResumeGame();
        _modal.gameObject.SetActive(false);

    }
}
