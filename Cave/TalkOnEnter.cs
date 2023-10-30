using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkOnEnter : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;

    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player collision with NPC");
            _panel.SetActive(true);
        }
    }
}
