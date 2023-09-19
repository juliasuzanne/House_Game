using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;


public class UIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _panel;

    [SerializeField]
    private GameObject _inventoryUI;

    private Image _item;

    GameManager _gameManager;

    private GameObject player;
    private GameObject _pickups;

    private Inventory inventory;


    public SaveObject so;

    // Start is called before the first frame update
    void Start()

    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player");

        _pickups = GameObject.FindGameObjectWithTag("Pickups");
        _panel.gameObject.SetActive(false);
        _inventoryUI.gameObject.SetActive(false);


        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("The GameManager is NULL");
        }
        if (_pickups == null)
        {
            Debug.LogError("The GameManager is NULL");
        }

        so.playerLevel = SceneManager.GetActiveScene().buildIndex;
        so.playerName = "Julia";

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            _panel.SetActive(true);
            _gameManager.PauseGame();
        }


    }

    public void ResumeGame()
    {
        _panel.SetActive(false);
        _gameManager.ResumeGame();
    }

    public void SaveGame()
    {
        SaveManager.Save(so);
    }

    public void HideInventory()
    {
        _inventoryUI.SetActive(false);

    }

    public void ShowInventory()
    {

        if (_inventoryUI.activeSelf == true)
        {
            _inventoryUI.SetActive(false);

        }
        else
        {
            _inventoryUI.SetActive(true);

        }
    }

    public void AddToInventory(int child)
    {
        _inventoryUI.transform.GetChild(child).gameObject.SetActive(true);
        ChangeSOInventory(child);

    }

    // void MakeInventoryUIVisible(int child)
    // {
    //     _item = _inventoryUI.transform.GetChild(child).GetComponent<Image>();
    //     _item.color = new Color(255, 255, 255, 1f);
    // }

    public void MakeInventoryUIShadow(int child)
    {
        _inventoryUI.transform.GetChild(child).gameObject.SetActive(false);
        switch (child)
        {
            case 2:
                so.leaf = false;
                break;
            case 1:
                so.band = false;
                break;
            case 0:
                so.rock = false;
                break;

        }
    }

    void ChangeSOInventory(int child)
    {
        switch (child)
        {
            case 2:
                so.leaf = true;
                break;
            case 1:
                so.band = true;
                break;
            case 0:
                so.rock = true;
                break;

        }
    }

    public void LoadGame()
    {
        so = SaveManager.Load();

        if (so.rock == true)
        {
            AddToInventory(0);
            _pickups.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            MakeInventoryUIShadow(0);
            _pickups.transform.GetChild(0).gameObject.SetActive(true);

        }
        if (so.band == true)
        {
            AddToInventory(1);
            _pickups.transform.GetChild(1).gameObject.SetActive(false);

        }
        else
        {
            MakeInventoryUIShadow(1);
            _pickups.transform.GetChild(1).gameObject.SetActive(true);


        }
        if (so.leaf == true)
        {
            AddToInventory(2);
            _pickups.transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            MakeInventoryUIShadow(2);
            _pickups.transform.GetChild(2).gameObject.SetActive(true);
        }


        // UpdateLives(so.playerLives);
        // _score = so.playerPoints;


    }

    // public void MainMenu()
    // {
    //     _panel.SetActive(false);
    //     SceneManager.LoadScene("MainMenu");

    // }

    // public void UpdateLives(int currentLives)
    // {
    //     _livesImage.sprite = _lifeSprites[currentLives];
    //     so.playerLives = currentLives;

    // }

    // public void PlayerDeath()
    // {
    //     _restartText.gameObject.SetActive(true);
    //     _gameOver = true;
    //     StartCoroutine("GameOverFlicker");

    // }

    // IEnumerator GameOverFlicker()
    // {
    //     while (true)
    //     {
    //         _gameOverText.gameObject.SetActive(true);
    //         yield return new WaitForSeconds(0.8f);
    //         _gameOverText.gameObject.SetActive(true);
    //         _restartText.gameObject.SetActive(true);
    //         yield return new WaitForSeconds(0.8f);
    //     }



    // }

    // public void LoadControls()
    // {
    //     SceneManager.LoadScene("Controls");
    // }

    //     public void AddPoints(int numToAdd)
    //     {
    //         _score += numToAdd;
    //         so.playerPoints = _score;

    //     }

}