using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    private Hand player;
    private GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Hand>();
        platform = GameObject.Find("Platform");

    }

    public void ResumeGame()
    {
        transform.gameObject.SetActive(false);
        platform.SetActive(false);
        player.UseGravity();

    }


    // Update is called once per frame
    void Update()
    {

    }
}
