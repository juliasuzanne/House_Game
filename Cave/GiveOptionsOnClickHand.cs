using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class GiveOptionsOnClickHand : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    [SerializeField]
    private Text _playerText;
    private bool collided = false;

    [SerializeField]
    private GameObject _panel;

    [SerializeField]
    private Button AButton;
    [SerializeField]
    private Button BButton;

    private bool runRoutine = true;

    public GameObject clicked_Object;

    private UIManager _uiManager;

    private Hand playerScript;

    private void Start()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Hand>();
        _playerText.gameObject.SetActive(false);
        _panel.SetActive(false);
        if (_uiManager == null)
        {
            Debug.Log("THE UI MANAGER IS NULL");
        }


    }

    void Update()
    {
        Vector3 playerPos = new Vector3(player.position.x, player.position.y, player.position.z);
        _playerText.gameObject.transform.position = playerPos;
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Mouse Down on Options");
        // _uiManager.HideInventory();
        playerScript.MoveableFalse();
        _panel.SetActive(true);
    }

    public void GiveOptions()
    {

        _uiManager.HideInventory();
        playerScript.MoveableFalse();
        _panel.SetActive(true);

    }

    public void OptionA()
    {
        Debug.Log("A PRESSED");
        playerScript.MoveableTrue();
        _panel.SetActive(false);
    }

    public void OptionB()
    {
        Debug.Log("B PRESSED");
        _uiManager.HideInventory();
        playerScript.MoveableTrue();
        _panel.SetActive(false);
    }


}





