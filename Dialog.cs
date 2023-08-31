using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    [SerializeField]
    private Text _playerText;
    [SerializeField]
    int _scalemove;
    [SerializeField]


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerText.gameObject.SetActive(true);
        _playerText.text = "Hello! How are you?";


    }

    void Update()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);

        Debug.Log("text: " + _playerText.gameObject.transform.position);

        _playerText.gameObject.transform.position = playerPos;
    }

    public void StartTalking()
    {

    }
}
